using System;

namespace TimeLibrary.Parser
{
    class StringToTimeParser
    {
        public static int GetHours(string timeString)
        {
            string[] time = timeString.Split(':');

            if (time.Length >= 1)
            {
                return Convert.ToByte(time[0]);
            }

            return 0;
        }

        public static byte GetMinutes(string timeString)
        {
            string[] time = timeString.Split(':');

            if (time.Length >= 2)
            {
                return Convert.ToByte(time[1]);
            }

            return 0;
        }

        public static byte GetSeconds(string timeString)
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
