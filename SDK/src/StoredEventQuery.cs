using System;
using Harbard;
using Harbard.Api;
using System.Diagnostics;

namespace Harbard
{
    public class StoredEventQuery
    {
        private StorageSession storageSession;
        private StorageEventsRequest storageEventsRequest;
        private Action<StorageEvents, ApiException?> callback;

        public StoredEventQuery(StorageSession sess, DateTime start, DateTime end, Action<StorageEvents, ApiException?> callback)
        {
            storageSession = sess;

            storageEventsRequest = new StorageEventsRequest();
            storageEventsRequest._StartTime = start;
            storageEventsRequest._EndTime = end;

            this.callback = callback;
        }

        public void runAsync()
        {
            storageSession.GetEventsAsync(storageEventsRequest, callback);
        }

        public StorageEvents run()
        {
            return storageSession.GetEvents(storageEventsRequest);
        }
    }
}