namespace Harbard
{
    namespace Api
    {
        public static class DateTimeConverter
        {
            public static DateTime convertToDateTime(long windows_timestamp)
            {
                DateTime startPoint = DateTime.Parse("1601.01.01");
                DateTime dateTime = startPoint + TimeSpan.FromMilliseconds(windows_timestamp);

                return dateTime;
            }

            public static long convertToTimeStamp(DateTime dateTime)
            {
                DateTime startPoint = DateTime.Parse("1601.01.01");

                TimeSpan timeSpan = dateTime.Subtract(startPoint);

                long elapsed = (long)timeSpan.TotalMilliseconds;

                return elapsed;
            }

            public static long convertToTimeStamp(TimeSpan timeSpan)
            {
                long elapsed = (long)timeSpan.TotalMilliseconds;

                return elapsed;
            }

            public static string formatDateTime(DateTime dateTime)
            {
                return dateTime.ToString("yyyy.MM.dd. HH:mm:ss.fff");
            } 
        }
    }
}