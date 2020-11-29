using System;
using TimeLibrary.Factory;
using TimeLibrary.Helper;
using TimeLibrary.Validator;

namespace TimeLibrary
{
    public class TimePeriod : IEquatable<TimePeriod>, IComparable<TimePeriod>
    {
        public readonly long TimeInSeconds;

        public TimePeriod(int hours, byte minutes, byte seconds)
        {
            TimeValidator.ValidateHours(hours);
            TimeValidator.ValidateMinutes(minutes);
            TimeValidator.ValidateSeconds(seconds);

            this.TimeInSeconds = TimeToSecondHelper.Get(hours, minutes, seconds);
        }

        public TimePeriod(int hours, byte minutes)
        {
            TimeValidator.ValidateHours(hours);
            TimeValidator.ValidateMinutes(minutes);

            this.TimeInSeconds = TimeToSecondHelper.Get(hours, minutes);
        }

        public TimePeriod(int hours)
        {
            TimeValidator.ValidateHours(hours);

            this.TimeInSeconds = TimeToSecondHelper.Get(hours);
        }

        public TimePeriod(string timeString)
        {
            int hours = TimeFactory.GetHours(timeString);
            byte minutes = TimeFactory.GetMinutes(timeString);
            byte seconds = TimeFactory.GetSeconds(timeString);

            TimeValidator.ValidateHours(hours);
            TimeValidator.ValidateMinutes(minutes);
            TimeValidator.ValidateSeconds(seconds);

            this.TimeInSeconds = TimeToSecondHelper.Get(hours, minutes, seconds);
        }

        public static bool operator ==(TimePeriod timePeriod1, TimePeriod timePeriod2) => timePeriod1.Equals(timePeriod2);
        public static bool operator !=(TimePeriod timePeriod1, TimePeriod timePeriod2) => !timePeriod1.Equals(timePeriod2);

        public static bool operator >(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.TimeInSeconds > timePeriod2.TimeInSeconds;
        }

        public static bool operator <(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.TimeInSeconds < timePeriod2.TimeInSeconds;
        }

        public static bool operator >=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.TimeInSeconds >= timePeriod2.TimeInSeconds;
        }

        public static bool operator <=(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1.TimeInSeconds <= timePeriod2.TimeInSeconds;
        }

        public static TimePeriod operator +(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            long timeInSeconds = timePeriod1.TimeInSeconds + timePeriod2.TimeInSeconds;

            return new TimePeriod(
                TimeFactory.GetSumHours(timeInSeconds),
                TimeFactory.GetMinutes(timeInSeconds),
                TimeFactory.GetSeconds(timeInSeconds)
            );
        }

        public static TimePeriod operator -(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            long timeInSeconds = timePeriod1.TimeInSeconds - timePeriod2.TimeInSeconds;

            if (timeInSeconds < 0)
            {
                throw new ArgumentException("It cannot be less than zero");
            }

            return new TimePeriod(
                TimeFactory.GetSumHours(timeInSeconds),
                TimeFactory.GetMinutes(timeInSeconds),
                TimeFactory.GetSeconds(timeInSeconds)
            );
        }

        public bool Equals(TimePeriod timePeriod)
        {
            return this.TimeInSeconds == timePeriod.TimeInSeconds;
        }

        public override bool Equals(object obj)
        {
            if (obj is TimePeriod timePeriod)
            {
                return Equals(timePeriod);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (int)(this.TimeInSeconds);
        }

        public int CompareTo(TimePeriod timePeriod)
        {
            if (this.Equals(timePeriod))
            {
                return 0;
            }

            if (this.TimeInSeconds < timePeriod.TimeInSeconds)
            {
                return 1;
            }

            return -1;
        }

        public override string ToString()
        {
            return ToStringParser.FromTimeInSeconds(TimeInSeconds);
        }

        public TimePeriod Plus(TimePeriod timePeriod)
        {
            return this + timePeriod;
        }

        public static TimePeriod Plus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1 + timePeriod2;
        }

        public TimePeriod Minus(TimePeriod timePeriod)
        {
            return this - timePeriod;
        }

        public static TimePeriod Minus(TimePeriod timePeriod1, TimePeriod timePeriod2)
        {
            return timePeriod1 - timePeriod2;
        }
    }
}
