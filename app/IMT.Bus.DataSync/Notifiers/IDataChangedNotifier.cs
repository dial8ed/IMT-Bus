namespace IMT.Bus.DataSync.Notifiers
{
    public interface IDataChangedNotifier<TData> : INotifier
    {       
        void NotifyListeners(TData data);
    }

    public interface INotifier
    {
        void StartListening();
        void StopListening();
    }
}