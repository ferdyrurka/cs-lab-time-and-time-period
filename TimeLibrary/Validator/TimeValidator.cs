using System;

namespace TimeLibrary.Validator
{
    class TimeValidator
    {
        public static void ValidateHour(byte value)
        {
            if (value < (byte)TimeEnum.MIN_HOUR || value > (byte)TimeEnum.MAX_HOUR)
            {
                throw new ArgumentException("hour" + value.ToString());
            }
        }

        public static void ValidateMinute(byte value)
        {
            if (value < (byte)TimeEnum.MIN_MINUTE || value > (byte)TimeEnum.MAX_MINUTE)
            {
                throw new ArgumentException("minute" + value.ToString());
            }
        }

        public static void ValidateSecond(byte value)
        {
            if (value < (byte)TimeEnum.MIN_SECOND || value > (byte)TimeEnum.MAX_SECOND)
            {
                throw new ArgumentException(value.ToString());
            }
        }
    }
}
