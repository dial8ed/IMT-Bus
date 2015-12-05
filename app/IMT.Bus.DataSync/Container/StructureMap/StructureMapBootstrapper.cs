using IMT.Bus.DataSync.Container.StructureMap.Registries;
using StructureMap;

namespace IMT.Bus.DataSync.Container.StructureMap
{
    public class StructureMapBootstrapper
    {
        public static void Initialize()
        {
            ObjectFactory.Configure((c) =>
                                        {
                                            c.AddRegistry<DataChangedNotifierRegistry>();
                                            c.AddRegistry<DataChangedListenerRegistry>();
                                        });            
        }
    }
}
