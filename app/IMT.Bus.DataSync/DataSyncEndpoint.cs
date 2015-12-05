using IMT.Bus.DataSync.Container.StructureMap;
using NServiceBus;
using StructureMap;

namespace IMT.Bus.DataSync
{
    [EndpointName("imt-datasync-input")]
    public class DataSyncEndpoint : IConfigureThisEndpoint, AsA_Publisher, IWantCustomInitialization
    {
        public void Init()
        {
            Configure.With().StructureMapBuilder().XmlSerializer();
            StructureMapBootstrapper.Initialize();
        }           
    }

    public class DataSyncStartup : IWantToRunAtStartup
    {
        public void Run()
        {
            ObjectFactory.GetInstance<NotificationService>().StartListening();            
        }

        public void Stop()
        {
            ObjectFactory.GetInstance<NotificationService>().StopListening();
        }
      
    }
}