namespace TimeLibrary
{
    class TimestampGenerator
    {
        public const int ONE_HOUR_IN_SECONDS = 3600;

        public const int ONE_MINUTE_IN_SECONDS = 60;

        public static long GetTimestamp(byte hours, byte minutes, byte seconds)
        {
            return (hours * ONE_HOUR_IN_SECONDS) + (minutes * ONE_MINUTE_IN_SECONDS) + seconds;
        }
    }
}
