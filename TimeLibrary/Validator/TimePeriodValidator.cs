using System;

namespace TimeLibrary.Validator
{
    class TimePeriodValidator
    {
        public static void ValidateHour(int value)
        {
            if (value < (byte) TimeEnum.MIN_HOUR)
            {
                throw new ArgumentException();
            }
        }

        public static void ValidateMinute(byte value)
        {
            if (value < (byte)TimeEnum.MIN_MINUTE || value > (byte)TimeEnum.MAX_MINUTE)
            {
                throw new ArgumentException();
            }
        }

        public static void ValidateSecond(byte value)
        {
            if (value < (byte)TimeEnum.MIN_SECOND || value > (byte)TimeEnum.MAX_SECOND)
            {
                throw new ArgumentException();
            }
        }
    }
}
