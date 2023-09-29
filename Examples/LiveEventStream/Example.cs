using Harbard;
using Harbard.Api;
using System.Net;

namespace Example 
{
    class LiveEventStreamExample 
    {
        static int Main(string[] args) 
        {
            if((args.Length < 3) || Array.Exists(args, element => (element.Equals("--help") || element.Equals("-h")))) 
            {
                Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} <Hostname|Ip> <Username> <Password>");
                return 0;
            }

            string address = args[0];
            string username = args[1];
            string password = args[2];

            using (var apiSession = new ApiSession(address, username, password /*port = 80, secureConnection = false*/))
            {
                if (apiSession) //login succeeded, apiSession is valid, contains apiSession.Session.Id
                {
                    using (LiveEventStream liveEventStream = new LiveEventStream(apiSession.Session, event_callback))
                    {
                        liveEventStream.Run(); //blocks until connection is closed or returning false from event callback
                    }
                }
                else if (apiSession.Session.LastError != null) //LastError check is for avoiding compile warning only
                {
                    //throw session.Session.LastError; OR
                    Console.Error.WriteLine(apiSession.Session.LastError.exceptionClass + " : " + apiSession.Session.LastError.errorMessage);
                }
            }
            return 0; 
        }

        private static bool event_callback(EventPackage event_package)
        {
            //If no events occure for a certain time a keepalive message will be sent by the device
            if (event_package.isKeepAlive)
            {
                //your code here
                //It is a good place to decide to continue reading events or to stop.
                Console.WriteLine($"Keepalive {DateTime.Now}");
                return true; //we decided to continue reading events
            }

            //Check for event image
            if ((event_package.image != null) && (event_package.image.data != null))
            {
                //your code here
                //event_package.image.data contains the event image binary
                //event_package.image.width, event_package.image.height holds the event image's dimensions
                //event_package.image.format holds the event image format

                //we chose to save image to disc
                File.WriteAllBytes("./" + event_package.image.imageId + event_package.image.format, event_package.image.data);
            }

            //Check for event metadata
            if (event_package.eventInfo != null)
            {
               
                //your code here
                //event_package.eventInfo is an object of Event class that provides several event specializations
                //<EventType>? current_event = event_package.eventInfo.as<EventType>();

                //we chose to check if it is an ANPR type event and write some info to console
                EventANPR? anprEvent = event_package.eventInfo.asEventANPR();
                if (anprEvent != null) //this is an ANPR event
                {
                    if (anprEvent._EventInfo != null) //check is for avoiding compile warning only
                    {
                        var event_info = anprEvent._EventInfo;
                        Console.WriteLine($"LicensePlate: {event_info._Text}, Country: {event_info._Country}");
                    }
                }

                //we chose to check if it is a TestEvent and write UTC EventTriggerTime to console
                EventTest? testEvent = event_package.eventInfo.asEventTest();
                if (testEvent != null) 
                {
                    Console.WriteLine($"TestEvent: {testEvent._EventTriggerTime}");
                }   

                //check for other event types by calling other as<EventType>() methods
                //we chose to print the detector class name of the emitted event
                Console.WriteLine($"EventClass: {event_package.eventInfo._Config._Class}");
            }

            return true;

        }
    }
}
