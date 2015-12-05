using System.Collections.Generic;
using IMT.Bus.Messages.Commands;
using NServiceBus;
using Order = IMT.Bus.Messages.Entities.Order;

namespace IMT.Bus.DataSync.DataChangedListeners
{
    public class OrderReceivedListener : IDataChangedListener<List<Order>>
    {
        private IBus _bus;

        public OrderReceivedListener(IBus bus)
        {
            _bus = bus;
        }

        public void Notify(List<Order> orders)
        {
            foreach (var order in orders)
            {                                                
                _bus.Send<IOrderReceived>("imt-publisher-input", o => { o.Order = order; });                
            }            
        }
    }
}