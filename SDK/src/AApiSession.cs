namespace Harbard
{
    public abstract class AApiSession
    {
        protected Session session;

        public Session Session
        {
            get { return session; }
        }

        public AApiSession(Session inputSession)
        {
            session = inputSession;
        }
    }
}
