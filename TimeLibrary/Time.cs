using System;

namespace TimeLibrary
{
    public class Time : IEquatable<Time>, IComparable<Time>
    {
        private byte Hours = 0;

        private byte Minutes = 0;

        private byte Seconds = 0;

        private long timestamp = 0;

        public Time(byte hours, byte minutes, byte seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;

            TimeValidator.validateHour(this.Hours);
            TimeValidator.validateMinute(this.Minutes);
            TimeValidator.validateSecond(this.Seconds);

            this.timestamp = TimestampGenerator.GetTimestamp(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(byte hours, byte minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;

            TimeValidator.validateHour(this.Hours);
            TimeValidator.validateMinute(this.Minutes);

            this.timestamp = TimestampGenerator.GetTimestamp(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(byte hours)
        {
            this.Hours = hours;

            TimeValidator.validateHour(this.Hours);

            this.timestamp = TimestampGenerator.GetTimestamp(this.Hours, this.Minutes, this.Seconds);
        }

        public Time(string timeString)
        {
            this.Hours = TimeStringParser.GetHours(timeString);
            this.Minutes = TimeStringParser.GetMinutes(timeString);
            this.Seconds = TimeStringParser.GetSeconds(timeString);

            TimeValidator.validateHour(this.Hours);
            TimeValidator.validateMinute(this.Minutes);
            TimeValidator.validateSecond(this.Seconds);

            this.timestamp = TimestampGenerator.GetTimestamp(this.Hours, this.Minutes, this.Seconds);
        }

        public static bool operator ==(Time time1, Time time2) => time1.Equals(time2);
        public static bool operator !=(Time time1, Time time2) => !time1.Equals(time2);

        public static bool operator >(Time time1, Time time2)
        {
            return time1.timestamp > time2.timestamp;
        }

        public static bool operator <(Time time1, Time time2)
        {
            return time1.timestamp < time2.timestamp;
        }

        public static bool operator >=(Time time1, Time time2)
        {
            return time1.timestamp >= time2.timestamp;
        }

        public static bool operator <=(Time time1, Time time2)
        {
            return time1.timestamp <= time2.timestamp;
        }

        public bool Equals(Time time)
        {
            return this.timestamp == time.timestamp;
        }

        public override bool Equals(object obj)
        {
            if (obj is Time)
            {
                return Equals((Time)obj);
            }

            return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return (int) (this.Hours + this.Minutes + this.Seconds + this.timestamp);
        }

        public int CompareTo(Time time)
        {
            if (this.Equals(time))
            {
                return 0;
            }

            if (this.timestamp < time.timestamp)
            {
                return 1;
            }

            return -1;
        }

        public override string ToString()
        {
            return Hours.ToString("D2") + ":" + Minutes.ToString("D2") + ":" + Seconds.ToString("D2");
        }
    }
}
