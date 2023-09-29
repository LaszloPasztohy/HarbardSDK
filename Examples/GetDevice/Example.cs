using Harbard;
using Harbard.Api;

namespace Example
{
    class GetDeviceExample
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

            using (var apiSession = new ApiSession(address, username, password))
            {
                if (apiSession) //login succeeded, apiSession is valid, contains apiSession.Session.Id
                {
                    try
                    {
                        var device_info = apiSession.System.GetDevice();
                        //we chose to print product info and firmware version, check api documentation for more
                        Console.WriteLine($"{device_info._Device._ProductName}-{device_info._Device._ProductSubclass} " +
                                          $"({device_info._Device._ProductDisplayName}) Version {device_info._Device._FirmwareVersion}");
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
