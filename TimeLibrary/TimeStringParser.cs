using System;

namespace TimeLibrary
{
    public class TimeStringParser
    {
        public static byte getHour(string timeString)
        {
            string[] time = timeString.Split(':');

            if (time.Length >= 1)
            {
                return Convert.ToByte(time[0]);
            }

            return 0;
        }

        public static byte getMinute(string timeString)
        {
            string[] time = timeString.Split(':');

            if (time.Length >= 2)
            {
                return Convert.ToByte(time[1]);
            }

            return 0;
        }

        public static byte getSecond(string timeString)
        {
            string[] time = timeString.Split(':');

            if (time.Length >= 3)
            {
                return Convert.ToByte(time[2]);
            }

            return 0;
        }
    }
}
