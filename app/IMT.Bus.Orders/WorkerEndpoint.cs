using NServiceBus;

namespace IMT.Bus.Orders
{
    [EndpointName("imt-order-input")]
    public class WorkerEndpoint : IConfigureThisEndpoint, AsA_Server { }

    public class WorkerInit : IWantCustomInitialization, IWantCustomLogging
    {      
        public void Init()
        {
            NServiceBus.SetLoggingLibrary.Log4Net(log4net.Config.XmlConfigurator.Configure);                                           
        }
    }
}
