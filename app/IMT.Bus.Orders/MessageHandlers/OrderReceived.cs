using System;
using IMT.Billing.Entities;
using IMT.Billing.Services;
using IMT.Bus.Messages.Commands;
using IMT.DAL.Controllers;
using NServiceBus;
using log4net;

namespace IMT.Bus.Orders.MessageHandlers
{
    public class OrderReceived : IHandleMessages<IOrderReceived>
    {
        public IBus Bus { get; set; }
        private static readonly ILog _logger = LogManager.GetLogger("OrderReceived");

        public OrderReceived(IBus bus)
        {
            Bus = bus;
        }

        public void Handle(IOrderReceived message)
        {           
            ServiceResult result = new ServiceResult() { Succeeded = false };
            try{
                
                var customerService = new CustomerService();
                var subscriptionService = new SubscriptionService();

                var customerInfo = new CustomerInfo();
                customerInfo.PopulateFromMessage(message);

                var paymentInfo = new PaymentInfo();
                paymentInfo.PopulateFromMessage(message);

                var addressInfo = new AddressInfo();
                addressInfo.PopulateFromMessage(message);

                var billingInfo = new BillingInfo(customerInfo, addressInfo);
                
                _logger.Info("Creating Customer");
                
                var customerResult = customerService.CreateCustomer(customerInfo);

                _logger.Info("Customer Created " + customerResult.ProfileId);

                _logger.Info("Creating Payment Subscription");

                var subscriptionResult = subscriptionService.CreatePaymentSubscription(customerInfo, paymentInfo,billingInfo);

                _logger.Info("Subscription Result: " + subscriptionResult.Message);

                result.Succeeded = subscriptionResult.Succeeded && customerResult.Succeeded;

            } 
            catch(Exception ex)
            {
                result.Succeeded = false;
                result.Exception = ex;
                result.Message = ex.Message;
                //Rollback(subscriptionService, customerService, customerResult, subscriptionResult);
            }

            if(result.Succeeded)
            {
                // Create Account in Product
                var controller = new AccountController();
                controller.CreateNewAccount(message.Order.Id);

                // Mark Order as Complete.
                OrderController.MarkAsComplete(message.Order.Id);
            } 
            else
            {
                _logger.Debug(result.Message);
            }
        }

        private void Rollback()
        {
            
        }
    }
}