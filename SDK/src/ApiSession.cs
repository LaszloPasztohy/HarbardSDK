using Harbard.Api;

namespace Harbard
{
    public class ApiSession : AApiSession, IDisposable
    {
        public static readonly int VERSION = 2; 
        private SystemSession systemSession;
        private AnalyticsSession analyticsSession;
        private StorageSession storageSession;
        private int apiVersion;

        public ApiSession(string inputAddress, string inputUser, string inputPassword, int inputPort = 80, bool secureConnection = false) 
                : base(new Session(inputAddress, inputUser, inputPassword, inputPort, secureConnection))
        {
            if(!session.login())
            {
                if(session.LastError != null)
                { throw new ApiException(session.LastError.exceptionClass, session.LastError.errorMessage); }
      
            }
            
            systemSession = new SystemSession(session);
            analyticsSession = new AnalyticsSession(session);
            storageSession = new StorageSession(session);

            if(isValid())
            {
                apiVersion = systemSession.GetApiVersion()._Version;

                if((apiVersion > 0) && (apiVersion != VERSION))
                {
                    throw new NotSupportedException($"Version mismatch! Device version({apiVersion}) != Api version({VERSION})");
                }
            }
        }

        public bool isValid()
        {
            return (session.Id != "");
        }

        public ApiException? LastError
        {
            get { return session.LastError; }
        }

        public static bool operator true(ApiSession session)
        { return session.isValid(); }
        public static bool operator false(ApiSession session)
        { return !session.isValid(); }

        public SystemSession System
        {
            get { return systemSession; }
        }

        public AnalyticsSession Analytics
        {
            get { return analyticsSession; }
        }

        public StorageSession Storage
        {
            get { return storageSession; }
        }

        public void Dispose()
        {
            Session.Dispose();
        }
    }
}