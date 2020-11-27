using System;
using TimeLibrary.Helper;
using TimeLibrary.Parser;
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

            TimeValidator.ValidateHour(this.Hours);
            TimeValidator.ValidateMinute(this.Minutes);
            TimeValidator.ValidateSecond(this.Seconds);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(byte hours, byte minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;

            TimeValidator.ValidateHour(this.Hours);
            TimeValidator.ValidateMinute(this.Minutes);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(byte hours)
        {
            this.Hours = hours;

            TimeValidator.ValidateHour(this.Hours);

            this.TimeInSeconds = TimeToSecondHelper.Get(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(string timeString)
        {
            this.Hours = (byte)(StringToTimeParser.GetHours(timeString));
            this.Minutes = StringToTimeParser.GetMinutes(timeString);
            this.Seconds = StringToTimeParser.GetSeconds(timeString);

            TimeValidator.ValidateHour(this.Hours);
            TimeValidator.ValidateMinute(this.Minutes);
            TimeValidator.ValidateSecond(this.Seconds);

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
            return TimeToStringParser.FromTime(Hours, Minutes, Seconds);
        }
    }
}
