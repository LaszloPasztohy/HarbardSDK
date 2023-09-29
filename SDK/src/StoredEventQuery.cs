using System;
using Harbard;
using Harbard.Api;
using System.Diagnostics;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

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

        public void RunAsync()
        {
            storageSession.GetEventsAsync(storageEventsRequest, callback);
        }

        public StorageEvents Run()
        {
            return storageSession.GetEvents(storageEventsRequest);
        }

        public EventImage? GetEventImage(Event storageEvent)
        {
            EventImage? event_image = null;
            string event_timestamp = DateTimeConverter.convertToTimeStamp(storageEvent._EventTime).ToString();
            string url = $"/playback/image?detector={storageEvent._DetectorID}&event={storageEvent._EventID}&timestamp={event_timestamp}&sid={storageSession.Session.Id}";
            (HttpResponseMessage? response, ApiResult? error) = storageSession.Session.requestHttpGet(url);

            if (response != null) 
            {
                using (StreamReader reader = new StreamReader(response.Content.ReadAsStream()))
                {
                    event_image = new EventImage();
                    var task = response.Content.ReadAsByteArrayAsync();
                    task.RunSynchronously();
                    event_image.data = task.Result;
                    //TODO missing image parameters parse from headers X-.....
                }
            }

            return event_image;
        }

        /*
        public EventVideo? GetEventVideo()
        {
            //TODO
        }*/
    }
}