using Harbard;
using Harbard.Api;
using System;

namespace Example 
{
    class LiveEventQueryExample
    {
        static int Main(string[] args)
        {
            if ((args.Length < 3) || Array.Exists(args, element => (element.Equals("--help") || element.Equals("-h"))))
            {
                Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} <Hostname|Ip> <Username> <Password>");
                return 0;
            }

            string address = args[0];
            string username = args[1];
            string password = args[2];

            bool use_https = true;//secure connection
            int default_https_port = 443;

            using (var apiSession = new ApiSession(address, username, password, default_https_port, use_https))
            {
                if (apiSession) //login succeeded, apiSession is valid, contains apiSession.Session.Id
                {
                    LiveEventQuery liveEventQuery = new LiveEventQuery(apiSession.Analytics, event_callback);
                    liveEventQuery.Run(); //blocks until connection is closed or returning false from event callback
                }
                else if (apiSession.Session.LastError != null) //LastError check is for avoiding compile warning only
                {
                    //throw session.Session.LastError; OR
                    Console.Error.WriteLine(apiSession.Session.LastError.exceptionClass + " : " + apiSession.Session.LastError.errorMessage);
                }
            }
            return 0;
        }

        private static bool event_callback(BufferedEvents? buffered_events, ApiException? api_error)
        {
            if (api_error != null)
            {
                //some error occured
                Console.WriteLine(api_error.ToString());
                return false;//stop receiving
            }
            else if (buffered_events != null)
            {
                Console.WriteLine($"discarded events count: {buffered_events._DiscardedEvents}");
                foreach (var analyticsEvent in buffered_events._EventList)
                {
                    //We chose to print detector name : event ID : event time
                    Console.WriteLine($"{analyticsEvent._Config._DisplayName} : {analyticsEvent._EventID} : {analyticsEvent._EventTime}");

                    //analyticsEvent is an object of Event class that provides several event specializations
                    //<EventType>? current_event = event_package.eventInfo.as<EventType>();

                    //we chose to check if it is an ANPR type event and write some info to console
                    EventANPR? anprEvent = analyticsEvent.asEventANPR();
                    if (anprEvent != null) //this is an ANPR event
                    {
                        if (anprEvent._EventInfo != null) //check is for avoiding compile warning only
                        {
                            var event_info = anprEvent._EventInfo;
                            Console.WriteLine($"LicensePlate: {event_info._Text}, Country: {event_info._Country}");
                        }
                    }

                    //we chose to check if it is a TestEvent and write UTC EventTriggerTime to console
                    EventTest? testEvent = analyticsEvent.asEventTest();
                    if (testEvent != null)
                    {
                        Console.WriteLine($"TestEvent: {testEvent._EventTriggerTime}");
                    }

                    //check for other event types by calling other as<EventType>() methods
                    //we chose to print the detector class name of the emitted event
                    Console.WriteLine($"EventClass: {analyticsEvent._Config._Class}");
                }
            }
            return true;
        }
    }
}
