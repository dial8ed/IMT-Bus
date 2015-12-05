using System.Collections.Generic;

namespace IMT.Bus.DataSync.Container
{
    public interface IContainer
    {
        IEnumerable<TInstance> GetAllInstancesOf<TInstance>();
        TInstance GetInstance<TInstance>();
    }
}