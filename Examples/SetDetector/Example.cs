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
            //Name of this detector instance displayed on user-facing interfaces:
            string detectorDisplayName = args[3];
            //Any quantity of license plates separated by spaces (as app arguments) are placed inside a List for better accessibility:
            List<string> licensePlates = new List<string>();
            for (int i = 4; i < args.Length; i++)
            { licensePlates.Add(args[i]); }
            //Supports wildcard for single(?) and multiple(*) characters (e.g.ABC?23).
            //Supports country codes with forward slash (e.g.GB/ABC123).

            using (var apiSession = new ApiSession(address, username, password))
            {
                if (apiSession) //login succeeded, apiSession is valid, contains apiSession.Session.Id
                {
                    try
                    {
                        //Get all detectors on the device:
                        DetectorList detectorList = apiSession.Analytics.GetDetectors();

                        //All detectors on the device with the specified DisplayName are found and their IDs are saved:
                        List<string> detectorIDs = new List<string>();
                        if(detectorList._Detectors != null) //Check is for avoiding compile warning only
                        {
                            foreach (var det in detectorList._Detectors)
                            {
                                if((det._DisplayName == detectorDisplayName) && (det._DetectorID != null))
                                { detectorIDs.Add(det._DetectorID); }
                            }
                        }

                        foreach (var detectorID in detectorIDs)
                        {
                            Detector detector = new Detector();
                            DetectorConfigurationANPR config = new DetectorConfigurationANPR();

                            //Unique ID of the detector instance (resolved above from the DisplayName):
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

                            //Overrides existing detector settings with new settings specified in code above:
                            apiSession.Analytics.SetDetector(detector);
                        }
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