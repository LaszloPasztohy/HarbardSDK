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

        public StoredEventQuery(StorageSession sess, DateTime start, DateTime end)
        {
            storageSession = sess;

            storageEventsRequest = new StorageEventsRequest();
            storageEventsRequest._StartTime = start;
            storageEventsRequest._EndTime = end;
        }

        public void RunAsync(Action<StorageEvents, ApiException?> callback)
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
                    task.Wait();
                    event_image.data = task.Result;
                    //Missing X- headers from StorageImage
                }
            }

            return event_image;
        }

        
        public EventVideo? GetEventVideo(Event storageEvent, TimeSpan? maxDuration = null)
        {
            EventVideo? event_video = null;
            if (maxDuration == null) { maxDuration = TimeSpan.FromSeconds(12); }
            TimeSpan half_duration = (TimeSpan)maxDuration / 2;

            var event_time = storageEvent._EventTime;
            string start_timestamp = DateTimeConverter.convertToTimeStamp(storageEvent._EventTime - half_duration).ToString();
            string end_timestamp = DateTimeConverter.convertToTimeStamp(storageEvent._EventTime + half_duration).ToString();

            string event_timestamp = DateTimeConverter.convertToTimeStamp(storageEvent._EventTime).ToString();
            string url = $"/playback/video?start={start_timestamp}&end={end_timestamp}&sid={storageSession.Session.Id}";
            (HttpResponseMessage? response, ApiResult? error) = storageSession.Session.requestHttpGet(url);

            if (response != null)
            {
                using (StreamReader reader = new StreamReader(response.Content.ReadAsStream()))
                {
                    event_video = new EventVideo();
                    var task = response.Content.ReadAsByteArrayAsync();
                    task.Wait();
                    event_video.data = task.Result;
                }
            }

            return event_video;
        }
    }
}