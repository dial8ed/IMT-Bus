using System;
using System.Collections.Generic;
using IMT.Bus.DataSync.Notifiers;

namespace IMT.Bus.DataSync
{
    public class NotificationService
    {
        private IEnumerable<INotifier> _notifiers;

        public NotificationService(IEnumerable<INotifier> notifiers)
        {
            _notifiers = notifiers;
        }

        public void StartListening()
        {
            foreach (var notifier in _notifiers)
            {
                notifier.StartListening();
            }
        }

        public void StopListening()
        {
            foreach (var notifier in _notifiers)
            {
                notifier.StopListening();
            }    
        }
    }
}