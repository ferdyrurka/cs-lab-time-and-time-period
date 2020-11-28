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

        public static byte GetMinutes(long timeInSeconds)
        {
            return (byte)(
                (timeInSeconds / (byte)TimeEnum.ONE_MINUTE_IN_SECONDS) % (byte)TimeEnum.ONE_MINUTE_IN_SECONDS
            );
        }

        public static byte GetSeconds(long timeInSeconds)
        {
            return (byte)(timeInSeconds % (byte)TimeEnum.ONE_MINUTE_IN_SECONDS);
        }
    }
}
