namespace IMT.Bus.DataSync.DataChangedListeners
{
    public interface IDataChangedListener<TData>
    {
        void Notify(TData data);
    }    
}