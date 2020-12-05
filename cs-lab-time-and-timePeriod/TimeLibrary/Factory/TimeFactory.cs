using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLibrary.Factory
{
    class TimeFactory
    {
        public static byte GetHours(long timeInSeconds)
        {
            int hours = (int)(timeInSeconds / (int)TimeEnum.ONE_HOUR_IN_SECONDS);

            if (hours > (int)TimeEnum.MAX_HOUR)
            {
                hours %= (int)TimeEnum.HOUR_IN_DAY;
            }

            return (byte) hours;
        }

        public static int GetSumHours(long timeInSeconds)
        {
            return (int)(timeInSeconds / (int)TimeEnum.ONE_HOUR_IN_SECONDS);
        }

        public static int GetHours(string timeString)
        {
            string[] time = timeString.Split(':');

            if (time.Length >= 1)
            {
                return Convert.ToByte(time[0]);
            }

            return 0;
        }

        public static byte GetMinutes(long timeInSeconds)
        {
            return (byte)(
                (timeInSeconds / (byte)TimeEnum.ONE_MINUTE_IN_SECONDS) % (byte)TimeEnum.ONE_MINUTE_IN_SECONDS
            );
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

        public static byte GetSeconds(long timeInSeconds)
        {
            return (byte)(timeInSeconds % (byte)TimeEnum.ONE_MINUTE_IN_SECONDS);
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
