using Harbard;
using Harbard.Api;
using System.Net;
using System;

namespace Example
{
    class StoredEventQueryExample
    {
        static int Main(string[] args)
        {
            if ((args.Length < 5) || Array.Exists(args, element => (element.Equals("--help") || element.Equals("-h"))))
            {
                Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} <Hostname|Ip> <Username> <Password> <Start_Time> <End_Time>");
                return 0;
            }

            string address = args[0];
            string username = args[1];
            string password = args[2];
            int default_http_port = 80;

            DateTime startTime = DateTime.Parse(args[3]);
            DateTime endTime = DateTime.Parse(args[4]);

            using (var apiSession = new ApiSession(address, username, password, default_http_port))
            {
                if (apiSession) //login succeeded, apiSession is valid, contains apiSession.Session.Id
                {
                    StoredEventQuery storedEventQuery = new StoredEventQuery(apiSession.Storage, startTime, endTime);

                    StorageEvents storageEvents = storedEventQuery.Run(); //runs once and returns with a list of events recorded in the given timeframe

                    if(storageEvents._EventList != null)
                    {
                        foreach (var storageEvent in storageEvents._EventList)
                        {
                            //We chose to print detector name : event ID : event time
                            Console.WriteLine($"{storageEvent._Config._DisplayName} : {storageEvent._EventID} : {storageEvent._EventTime}");

                            var image = storedEventQuery.GetEventImage(storageEvent);
                            if ((image != null) && (image.data != null))
                            { File.WriteAllBytes("./" + storageEvent._EventID + "." + image.format, image.data); }

                            var video = storedEventQuery.GetEventVideo(storageEvent);
                            if ((video != null) && (video.data != null))
                            { File.WriteAllBytes("./" + storageEvent._EventID + "." + video.format, video.data); }
                        }
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
    }
}