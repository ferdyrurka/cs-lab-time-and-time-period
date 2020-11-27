namespace TimeLibrary.Helper
{
    class TimeToSecondHelper
    {
        public static long Get(int hours, byte minutes = 0, byte seconds = 0)
        {
            return (hours * TimeEnum.ONE_HOUR_IN_SECONDS) + (minutes * TimeEnum.ONE_MINUTE_IN_SECONDS) + seconds;
        }
    }
}
