using System;

namespace TimeLibrary.Validator
{
    class TimeValidator
    {
        public static void ValidateHours(byte value)
        {
            if (value < (byte)TimeEnum.MIN_HOUR || value > (byte)TimeEnum.MAX_HOUR)
            {
                throw new ArgumentException();
            }
        }

        public static void ValidateHours(int value)
        {
            if (value < (byte)TimeEnum.MIN_HOUR)
            {
                throw new ArgumentException();
            }
        }

        public static void ValidateMinutes(byte value)
        {
            if (value < (byte)TimeEnum.MIN_MINUTE || value > (byte)TimeEnum.MAX_MINUTE)
            {
                throw new ArgumentException();
            }
        }

        public static void ValidateSeconds(byte value)
        {
            if (value < (byte)TimeEnum.MIN_SECOND || value > (byte)TimeEnum.MAX_SECOND)
            {
                throw new ArgumentException();
            }
        }
    }
}
