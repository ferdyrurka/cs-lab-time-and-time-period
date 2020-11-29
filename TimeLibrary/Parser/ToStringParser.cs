using TimeLibrary.Factory;

namespace TimeLibrary
{
    class ToStringParser
    {
        public static string FromTimeInSeconds(long timeInSeconds)
        {
            return TimeFactory.GetSumHours(timeInSeconds).ToString("D2") + ":"
                + TimeFactory.GetMinutes(timeInSeconds).ToString("D2") + ":"
                + TimeFactory.GetSeconds(timeInSeconds).ToString("D2")
            ;
        }

        public static string FromTime(byte hours, byte minutes, byte seconds)
        {
            return hours.ToString("D2") + ":" + minutes.ToString("D2") + ":" + seconds.ToString("D2");
        }
    }
}
