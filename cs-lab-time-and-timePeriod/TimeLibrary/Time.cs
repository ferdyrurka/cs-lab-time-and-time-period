using System;
using TimeLibrary.Factory;
using TimeLibrary.Helper;
using TimeLibrary.Validator;

namespace TimeLibrary
{
    public class Time : IEquatable<Time>, IComparable<Time>
    {
        private readonly byte Hours = 0;

        private readonly byte Minutes = 0;

        private readonly byte Seconds = 0;

        private readonly long TimeInSeconds = 0;

        public Time(byte hours, byte minutes, byte seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;

            TimeValidator.ValidateHours(this.Hours);
            TimeValidator.ValidateMinutes(this.Minutes);
            TimeValidator.ValidateSeconds(this.Seconds);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(byte hours, byte minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;

            TimeValidator.ValidateHours(this.Hours);
            TimeValidator.ValidateMinutes(this.Minutes);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(byte hours)
        {
            this.Hours = hours;

            TimeValidator.ValidateHours(this.Hours);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(string timeString)
        {
            this.Hours = (byte)TimeFactory.GetHours(timeString);
            this.Minutes = TimeFactory.GetMinutes(timeString);
            this.Seconds = TimeFactory.GetSeconds(timeString);

            TimeValidator.ValidateHours(this.Hours);
            TimeValidator.ValidateMinutes(this.Minutes);
            TimeValidator.ValidateSeconds(this.Seconds);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public static bool operator ==(Time time1, Time time2) => time1.Equals(time2);
        public static bool operator !=(Time time1, Time time2) => !time1.Equals(time2);

        public static bool operator >(Time time1, Time time2)
        {
            return time1.TimeInSeconds > time2.TimeInSeconds;
        }

        public static bool operator <(Time time1, Time time2)
        {
            return time1.TimeInSeconds < time2.TimeInSeconds;
        }

        public static bool operator >=(Time time1, Time time2)
        {
            return time1.TimeInSeconds >= time2.TimeInSeconds;
        }

        public static bool operator <=(Time time1, Time time2)
        {
            return time1.TimeInSeconds <= time2.TimeInSeconds;
        }

        public static Time operator +(Time time, TimePeriod timePeriod)
        {
            long timeInSeconds = timePeriod.TimeInSeconds + time.TimeInSeconds;

            return new Time(
                TimeFactory.GetHours(timeInSeconds),
                TimeFactory.GetMinutes(timeInSeconds),
                TimeFactory.GetSeconds(timeInSeconds)
            );
        }

        public static Time operator -(Time time, TimePeriod timePeriod)
        {
            long timeInSeconds = time.TimeInSeconds - timePeriod.TimeInSeconds;

            if (timeInSeconds < 0)
            {
                byte periodHours = TimeFactory.GetHours(timePeriod.TimeInSeconds);
                byte periodMinutes = TimeFactory.GetMinutes(timePeriod.TimeInSeconds);
                byte periodSeconds = TimeFactory.GetSeconds(timePeriod.TimeInSeconds);
                
                int hours = time.Hours - periodHours;
                int minutes = time.Minutes - periodMinutes;
                int seconds = time.Seconds - periodSeconds;

                if (hours < (byte)TimeEnum.MIN_HOUR)
                {
                    hours = periodHours - time.Hours;
                }

                if (minutes < (byte)TimeEnum.MIN_MINUTE)
                {
                    minutes = periodMinutes - time.Minutes;
                }

                if (seconds < (byte)TimeEnum.MIN_SECOND)
                {
                    seconds = periodSeconds - time.Seconds;
                }

                return new Time(
                    (byte)hours,
                    (byte)minutes,
                    (byte)seconds
                );
            }

            return new Time(
                TimeFactory.GetHours(timeInSeconds),
                TimeFactory.GetMinutes(timeInSeconds),
                TimeFactory.GetSeconds(timeInSeconds)
            );
        }

        public bool Equals(Time time)
        {
            return this.TimeInSeconds == time.TimeInSeconds;
        }

        public override bool Equals(object obj)
        {
            if (obj is Time time)
            {
                return Equals(time);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (int) (this.Hours + this.Minutes + this.Seconds + this.TimeInSeconds);
        }

        public int CompareTo(Time time)
        {
            if (this.Equals(time))
            {
                return 0;
            }

            if (this.TimeInSeconds < time.TimeInSeconds)
            {
                return 1;
            }

            return -1;
        }

        public override string ToString()
        {
            return ToStringParser.FromTime(Hours, Minutes, Seconds);
        }

        public Time Plus(TimePeriod timePeriod)
        {
            return this + timePeriod;
        }

        public static Time Plus(Time time, TimePeriod timePeriod)
        {
            return time + timePeriod;
        }

        public Time Minus(TimePeriod timePeriod)
        {
            return this - timePeriod;
        }

        public static Time Minus(Time time, TimePeriod timePeriod)
        {
            return time - timePeriod;
        }
    }
}
