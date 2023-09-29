using System.Text;
using Harbard.Api;
using Newtonsoft.Json.Linq;

namespace Harbard
{
    public class LiveEventStream : IDisposable
    {
        private Session session;
        private bool containImages;
        private int keepalive;
        private List<string>? detectorFilters;
        private Func<EventPackage, bool> eventCallback;
        private EventImage? image;
        private TimeSpan readTimeout;
        private HttpMultiPartStream httpMultiPartStream;


        /// <summary>
        /// Live events can be continuously downloaded by sending an authenticated GET request to the device on: http://DEVICE_IP/live/events
        /// The device will respond with a multipart/mixed type connection and start sending events and associated images as they are emitted.
        /// </summary>
        /// <param name="session"> An active device session used to execute commands. </param>
        /// <param name="event_callback"> Callback function that processes incoming events and sends a stop request when the stream needs to stop. </param>
        /// <param name="contain_images"> Stream includes event images if set to true, doesn't include event images if set to false.
        ///                                 Default value: true.  </param>
        /// <param name="keepalive"> Keepalive messages are sent by the device to stop the connection from closing prematurely.
        ///                                 Set a duration in seconds to activate these keepalive messages. Turned off if value is set to -1. 
        ///                                 Default value: 10 seconds </param>
        /// <param name="detector_filters"> The stream contains all events from all detectors by default.
        ///                                 The events can be filtered by providing a comma separated list of detector ids.
        ///                                 Default value: null (no detector ids) </param>
        /// <param name="read_timeout"> Set a duration in seconds to send timeout messages to keep the connection alive
        ///                                 if the connection is empty for the set amount of time.
        ///                                 Default value: a TimeSpan of 15 seconds. </param>
        /// <exception cref="InvalidDataException"> Thrown if Keepalive is zero or negative (other than -1) </exception>        

        public LiveEventStream(Session session, Func<EventPackage, bool> event_callback, bool contain_images = true, int keepalive_seconds = 10,
                               List<string>? detector_filters = null, int read_timeout_seconds = 15)
        {
            this.session = session;
            containImages = contain_images;
            keepalive = keepalive_seconds;
            detectorFilters = detector_filters;
            eventCallback = event_callback;

            readTimeout = new TimeSpan(0, 0, read_timeout_seconds);

            image = null;


            string url = "http://" + this.session.Address + ":" + this.session.Port + "/live/events?sid=" + this.session.Id;


            if(!containImages)
            { url += "&image=0"; }


            if(this.keepalive > 0)
            { url += "&keepalive=" + this.keepalive; }
            else if((this.keepalive == 0) || (this.keepalive < -1))
            { throw new InvalidDataException("KeepAlive cannot be zero or negative (other than -1 [turned off]). Enter valid data"); }


            if((detectorFilters != null) && (detectorFilters.Count > 0))
            {
                url += "&filter=" + detectorFilters[0];

                if(detectorFilters.Count > 1)
                {
                    for(int det_filters_index = 1; det_filters_index < detectorFilters.Count; ++det_filters_index)
                    {
                        url += "," + detectorFilters[det_filters_index];
                    }
                }
            }


            httpMultiPartStream = new HttpMultiPartStream(url, content_callback, readTimeout);
        }

        public void Run()
        {
            httpMultiPartStream.Run();
        }

        public void RunAsync(Action<Exception> error_callback)
        {
            httpMultiPartStream.RunAsync(error_callback);
        }

        public void Dispose()
        {
            httpMultiPartStream.Dispose();
        }

        public void StopAsync()
        {
            httpMultiPartStream.StopAsync();
        }



        private bool content_callback(Dictionary<string , string> headers, byte[]? content)
        {
            string content_type = headers["Content-Type"];
            
            if(content_type == "image/jpeg")
            {
                if(content != null)
                {
                    image = new EventImage();

                    image.index = Convert.ToInt32(headers["X-Image-Index"]);
                    image.data = content;
                    image.width = Convert.ToInt32(headers["X-Frame-Width"]);
                    image.height = Convert.ToInt32(headers["X-Frame-Height"]);
                    image.imageId = Convert.ToInt32(headers["X-Frame-Id"]);
                }
            }
            else if(content_type == "application/json")
            {
                if(content != null)
                {
                    int event_index = Convert.ToInt32(headers["X-Event-Index"]);

                    string event_as_str = Encoding.UTF8.GetString(content);
                    JObject event_as_jobj = JObject.Parse(event_as_str);

                    EventPackage eventPackage = new EventPackage();
                    eventPackage.eventInfo = new Event();

                    eventPackage.eventInfo.deserialize(event_as_jobj);
                    eventPackage.index = event_index;

                    if((image != null) && (image.index == event_index))
                    { eventPackage.image = image; }


                    Task.Run(() => 
                    {
                        bool continue_reading = eventCallback(eventPackage);
                        if(!continue_reading)
                        { StopAsync(); }
                    });
                }
            }
            else if(content_type == "application/x-keepalive")
            {                
                EventPackage eventPackage = new EventPackage();

                eventPackage.isKeepAlive = true;

                Task.Run(() => 
                {
                    bool continue_reading = eventCallback(eventPackage);
                    if(!continue_reading)
                    { StopAsync(); }
                });
            }


            return true;
        }
    }
}