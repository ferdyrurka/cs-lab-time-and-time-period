namespace TimeLibrary
{
    class TimeToStringParser
    {
        public static string FromTimeInSeconds(long timeInSeconds)
        {
            int hours = (int)(timeInSeconds / (int)TimeEnum.ONE_HOUR_IN_SECONDS);
            int minutesInSeconds = (int)(timeInSeconds % (int)TimeEnum.ONE_HOUR_IN_SECONDS);
            byte seconds = (byte)(minutesInSeconds % (byte)TimeEnum.ONE_MINUTE_IN_SECONDS);

            return hours.ToString("D2") + ":"
                + (minutesInSeconds / (byte)TimeEnum.ONE_MINUTE_IN_SECONDS).ToString("D2") + ":"
                + seconds.ToString("D2")
            ;
        }

        public static string FromTime(byte hours, byte minutes, byte seconds)
        {
            return hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }
    }
}
