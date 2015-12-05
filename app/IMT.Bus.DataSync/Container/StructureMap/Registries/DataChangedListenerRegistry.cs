using IMT.Bus.DataSync.DataChangedListeners;
using StructureMap.Configuration.DSL;

namespace IMT.Bus.DataSync.Container.StructureMap.Registries
{
    internal class DataChangedListenerRegistry : Registry
    {
        public DataChangedListenerRegistry()
        {
            Scan(s =>
                     {
                         s.TheCallingAssembly();
                         s.AddAllTypesOf(typeof(IDataChangedListener<>));
                     });
        }
    }
}
