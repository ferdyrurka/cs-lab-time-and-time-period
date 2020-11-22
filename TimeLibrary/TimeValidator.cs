using System;
using System.Collections.Generic;
using System.Text;

namespace TimeLibrary
{
    class TimeValidator
    {
        private const int MIN_HOUR = 0;
        private const int MAX_HOUR = 23;

        private const int MIN_MINUTE = 0;
        private const int MAX_MINUTE = 59;

        private const int MIN_SECOND = 0;
        private const int MAX_SECOND = 59;

        public static void validateHour(byte value)
        {
            if (value < MIN_HOUR || value > MAX_HOUR)
            {
                throw new ArgumentException();
            }
        }

        public static void validateMinute(byte value)
        {
            if (value < MIN_MINUTE || value > MAX_MINUTE)
            {
                throw new ArgumentException();
            }
        }

        public static void validateSecond(byte value)
        {
            if (value < MIN_SECOND || value > MAX_SECOND)
            {
                throw new ArgumentException();
            }
        }
    }
}
