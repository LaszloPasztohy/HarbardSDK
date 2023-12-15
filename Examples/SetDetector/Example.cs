using Harbard;
using Harbard.Api;

namespace Example
{
    class SetDetectorExample
    {
        static int Main(string[] args)
        {
            if ((args.Length < 5) || Array.Exists(args, element => (element.Equals("--help") || element.Equals("-h"))))
            {
                Console.WriteLine($"Usage: {System.AppDomain.CurrentDomain.FriendlyName} <Hostname|Ip> <Username> <Password> <DetectorID> <List of License Plates (Space Separated)>");
                return 0;
            }

            string address = args[0];
            string username = args[1];
            string password = args[2];
            string detectorID = args[3];
            List<string> licensePlates = new List<string>();            
            for (int i = 4; i < args.Length; i++)
            { licensePlates.Add(args[i]); }
            
            using (var apiSession = new ApiSession(address, username, password))
            {
                if (apiSession) //login succeeded, apiSession is valid, contains apiSession.Session.Id
                {
                    try
                    {
                        Detector detector = new Detector();
                        DetectorConfigurationANPR config = new DetectorConfigurationANPR();

                        //Unique ID of the detector instance:
                        detector._DetectorID = detectorID;
                        //Enable detector:
                        config._Enabled = true;
                        //Enable filter usage:
                        config._Whitelist = true;
                        //List of license plates to signal for:
                        string filter = "";
                        foreach (var licensePlate in licensePlates)
                        { filter += licensePlate + "\n"; }

                        config._Filter = filter;
                        detector._Config = config;

                        apiSession.Analytics.SetDetector(detector);
                    }
                    catch (ApiException e)
                    {
                        Console.WriteLine(e.ToString());
                    }
                }
                else if (apiSession.Session.LastError != null) //LastError check is for avoiding compile warning only
                {
                    //throw session.Session.LastError; or
                    Console.Error.WriteLine(apiSession.Session.LastError.exceptionClass + " : " + apiSession.Session.LastError.errorMessage);
                }
            }

            return 0;
        }
    }
}