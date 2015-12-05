using IMT.Bus.DataSync.Notifiers;
using StructureMap.Configuration.DSL;

namespace IMT.Bus.DataSync.Container.StructureMap.Registries
{
    public class DataChangedNotifierRegistry : Registry
    {
        public DataChangedNotifierRegistry()
        {
            Scan(s =>
                     {
                         s.TheCallingAssembly();
                         s.AddAllTypesOf<INotifier>();
                     });
        }
    }
}