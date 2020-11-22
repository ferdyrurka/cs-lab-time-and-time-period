using System;

namespace TimeLibrary
{
    public class Time : IEquatable<Time>, IComparable<Time>
    {
        public const int ONE_HOUR_IN_SECONDS = 3600;

        public const int ONE_MINUTE_IN_SECONDS = 60;

        private byte Hours = 0;

        private byte Minutes = 0;

        private byte Seconds = 0;

        private int TimeStamp = 0;

        public Time(byte hours, byte minutes, byte seconds)
        {
            this.Hours = hours;
            this.Minutes = minutes;
            this.Seconds = seconds;

            TimeValidator.validateHour(this.Hours);
            TimeValidator.validateMinute(this.Minutes);
            TimeValidator.validateSecond(this.Seconds);

            this.TimeStamp = (this.Hours * ONE_HOUR_IN_SECONDS) + (this.Minutes * ONE_MINUTE_IN_SECONDS) + this.Seconds;
        }

        public Time(byte hours, byte minutes)
        {
            this.Hours = hours;
            this.Minutes = minutes;

            TimeValidator.validateHour(this.Hours);
            TimeValidator.validateMinute(this.Minutes);

            this.TimeStamp = (this.Hours * ONE_HOUR_IN_SECONDS) + (this.Minutes * ONE_MINUTE_IN_SECONDS);
        }

        public Time(byte hours)
        {
            this.Hours = hours;

            TimeValidator.validateHour(this.Hours);

            this.TimeStamp = this.Hours * ONE_HOUR_IN_SECONDS;
        }

        public Time(string timeString)
        {
            this.Hours = TimeStringParser.getHour(timeString);
            this.Minutes = TimeStringParser.getMinute(timeString);
            this.Seconds = TimeStringParser.getSecond(timeString);

            TimeValidator.validateHour(this.Hours);
            TimeValidator.validateMinute(this.Minutes);
            TimeValidator.validateSecond(this.Seconds);

            this.TimeStamp = (this.Hours * ONE_HOUR_IN_SECONDS) + (this.Minutes * ONE_MINUTE_IN_SECONDS) + this.Seconds;
        }

        public static bool operator ==(Time time1, Time time2) => time1.Equals(time2);
        public static bool operator !=(Time time1, Time time2) => !time1.Equals(time2);

        public static bool operator >(Time time1, Time time2)
        {
            return time1.TimeStamp > time2.TimeStamp;
        }

        public static bool operator <(Time time1, Time time2)
        {
            return time1.TimeStamp < time2.TimeStamp;
        }

        public static bool operator >=(Time time1, Time time2)
        {
            return time1.TimeStamp >= time2.TimeStamp;
        }

        public static bool operator <=(Time time1, Time time2)
        {
            return time1.TimeStamp <= time2.TimeStamp;
        }

        public bool Equals(Time time)
        {
            return this.TimeStamp == time.TimeStamp;
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
            return this.Hours + this.Minutes + this.Seconds + this.TimeStamp;
        }

        public int CompareTo(Time time)
        {
            if (this.Equals(time))
            {
                return 0;
            }

            if (this.TimeStamp < time.TimeStamp)
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
