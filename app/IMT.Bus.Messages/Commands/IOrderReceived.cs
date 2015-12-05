using NServiceBus;
using Order = IMT.Bus.Messages.Entities.Order;

namespace IMT.Bus.Messages.Commands
{
    public interface IOrderReceived : ICommand
    {
        Order Order { get; set; }         
    }
}