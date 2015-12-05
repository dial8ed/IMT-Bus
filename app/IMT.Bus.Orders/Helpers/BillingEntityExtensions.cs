using System;
using IMT.Billing.Entities;
using IMT.Bus.Messages.Commands;

namespace IMT.Bus.Orders
{
    public static class BillingEntityExtensions
    {
        // TODO: Setup AutoMapper
        public static void PopulateFromMessage(this CustomerInfo customer, IOrderReceived message)
        {
            customer.Description = message.Order.Subdomain;
            customer.FirstName = message.Order.FirstName;
            customer.LastName = message.Order.LastName;
            customer.Company = message.Order.Company;          
            customer.Subdomain = message.Order.Subdomain;
            customer.Tier = message.Order.Tier;
                       
            customer.Contact.Email = message.Order.Email;
        }

        public static void PopulateFromMessage(this PaymentInfo payment, IOrderReceived message)
        {
            dynamic orderDetails = Helpers.OrderDetailsParser.Parse(message.Order.Details);
            payment.Amount = message.Order.Price;
            payment.Description = message.Order.Tier.ToString();

            payment.Card.CardNumber = orderDetails.cc_number;
            payment.Card.CardCode = orderDetails.security_code;            
            payment.Card.ExpirationMonth = Int32.Parse(orderDetails.exp_month);
            payment.Card.ExpirationYear = Int32.Parse(orderDetails.exp_year);
            payment.Card.ExpirationDate = orderDetails.exp_month + orderDetails.exp_year;
        }

        public static void PopulateFromMessage(this AddressInfo address, IOrderReceived message)
        {
            address.City = "";      
            address.Country = message.Order.Country;
            address.Street = message.Order.StreetAddress;
            address.Postal = message.Order.Postal;            
        }
    }
}