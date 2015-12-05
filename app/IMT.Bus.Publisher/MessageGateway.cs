using IMT.Bus.Messages.Commands;
using NServiceBus;

namespace IMT.Bus.Publisher
{
    public class MessageGateway : IHandleMessages<IMessage>
    {
        public IBus Bus { get; set; }
        
        public void Handle(IMessage message)
        {
            if (message is IOrderReceived)
                Bus.Send("imt-order-input", message);
            else
                Bus.Publish(message);            
        }
    }
}
