using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TimeLibrary;

namespace TimeLibraryUnitTests
{
    [TestClass]
    public class TimePeriodTest
    {
        [TestMethod]
        [DataRow(0, 0, 0, "00:00:00")]
        [DataRow(09, 25, 16, "09:25:16")]
        [DataRow(10, 3, 44, "10:03:44")]
        [DataRow(11, 32, 4, "11:32:04")]
        [DataRow(1, 3, 6, "01:03:06")]
        [DataRow(120, 33, 46, "120:33:46")]
        [DataRow(93, 59, 59, "93:59:59")]
        public void CreateByHourMinuteSecond(int hour, int minute, int second, string expected)
        {
            TimePeriod time = new TimePeriod(Convert.ToByte(hour), Convert.ToByte(minute), Convert.ToByte(second));

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow(0, 0, "00:00:00")]
        [DataRow(12, 43, "12:43:00")]
        [DataRow(10, 9, "10:09:00")]
        [DataRow(9, 59, "09:59:00")]
        [DataRow(1, 7, "01:07:00")]
        [DataRow(65, 59, "65:59:00")]
        public void CreateByHourMinute(int hour, int minute, string expected)
        {
            TimePeriod time = new TimePeriod(Convert.ToByte(hour), Convert.ToByte(minute));

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow(0, "00:00:00")]
        [DataRow(4, "04:00:00")]
        [DataRow(78, "78:00:00")]
        [DataRow(230, "230:00:00")]
        public void CreateByHour(int hour, string expected)
        {
            TimePeriod time = new TimePeriod(Convert.ToByte(hour));

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow("0:0:0", "00:00:00")]
        [DataRow("0:0", "00:00:00")]
        [DataRow("9:32", "09:32:00")]
        [DataRow("9:8", "09:08:00")]
        [DataRow("19:8", "19:08:00")]
        [DataRow("21:27", "21:27:00")]
        [DataRow("23:59", "23:59:00")]
        [DataRow("230:59:59", "230:59:59")]
        [DataRow("214:41:12", "214:41:12")]
        [DataRow("9:41:12", "09:41:12")]
        [DataRow("21:4:12", "21:04:12")]
        [DataRow("21:45:2", "21:45:02")]
        public void CreateByString(string timeInString, string expected)
        {
            TimePeriod time = new TimePeriod(timeInString);

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-100)]
        [ExpectedException(typeof(ArgumentException))]
        public void LessThanHour(byte hour)
        {
            new TimePeriod(hour);
        }

        [TestMethod]
        [DataRow(-60)]
        [DataRow(-100)]
        [DataRow(60)]
        [DataRow(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void LessOrMoreThanMinute(byte minute)
        {
            new TimePeriod(21, minute);
        }

        [TestMethod]
        [DataRow(-60)]
        [DataRow(-100)]
        [DataRow(60)]
        [DataRow(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void LessOrMoreThanSecond(byte second)
        {
            new TimePeriod(150, 20, second);
        }

        [TestMethod]
        [DynamicData(nameof(MoreThanDataSet))]
        public void MoreThan(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1 > time2, expected);
        }

        public static IEnumerable<object[]> MoreThanDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(12), new TimePeriod(13), false},
            new object[] {new TimePeriod(13), new TimePeriod(12), true},
            new object[] {new TimePeriod(20, 20), new TimePeriod(20, 21), false},
            new object[] {new TimePeriod(18, 51), new TimePeriod(18, 50), true},
            new object[] {new TimePeriod(120, 40, 41), new TimePeriod(120, 40, 42), false},
            new object[] {new TimePeriod(9, 10, 11), new TimePeriod(9, 10, 10), true},
        };

        [TestMethod]
        [DynamicData(nameof(LessThanDataSet))]
        public void LessThan(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1 < time2, expected);
        }

        public static IEnumerable<object[]> LessThanDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(9), new TimePeriod(8), false},
            new object[] {new TimePeriod(22), new TimePeriod(23), true},
            new object[] {new TimePeriod(210, 10), new TimePeriod(210, 9), false},
            new object[] {new TimePeriod(13, 50), new TimePeriod(13, 51), true},
            new object[] {new TimePeriod(15, 25, 25), new TimePeriod(15, 25, 24), false},
            new object[] {new TimePeriod(1, 17, 57), new TimePeriod(1, 17, 58), true},
        };

        [TestMethod]
        [DynamicData(nameof(EqualOperatorDataSet))]
        public void EqualOperator(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1 == time2, expected);
        }

        public static IEnumerable<object[]> EqualOperatorDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(9), new TimePeriod(8), false},
            new object[] {new TimePeriod(22), new TimePeriod(22), true},
            new object[] {new TimePeriod(1, 10), new TimePeriod(12, 2), false},
            new object[] {new TimePeriod(13, 50), new TimePeriod(13, 50), true},
            new object[] {new TimePeriod(21, 7, 32), new TimePeriod(14, 11, 9), false},
            new object[] {new TimePeriod(1500, 25, 25), new TimePeriod(1500, 25, 25), true},
        };

        [TestMethod]
        [DynamicData(nameof(NotEqualOperatorDataSet))]
        public void NotEqualOperator(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1 != time2, expected);
        }

        public static IEnumerable<object[]> NotEqualOperatorDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(9), new TimePeriod(8), true},
            new object[] {new TimePeriod(22), new TimePeriod(22), false},
            new object[] {new TimePeriod(1, 10), new TimePeriod(12, 2), true},
            new object[] {new TimePeriod(113, 50), new TimePeriod(113, 50), false},
            new object[] {new TimePeriod(21, 7, 32), new TimePeriod(14, 11, 9), true},
            new object[] {new TimePeriod(15, 25, 25), new TimePeriod(15, 25, 25), false},
        };

        [TestMethod]
        [DynamicData(nameof(EqualDataSet))]
        public void Equal(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1.Equals(time2), expected);
        }

        public static IEnumerable<object[]> EqualDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(2300), new TimePeriod(90), false},
            new object[] {new TimePeriod(12), new TimePeriod(12), true},
            new object[] {new TimePeriod(12, 15), new TimePeriod(13, 52), false},
            new object[] {new TimePeriod(16, 59), new TimePeriod(16, 59), true},
            new object[] {new TimePeriod(23, 27, 17), new TimePeriod(12, 21, 39), false},
            new object[] {new TimePeriod(12, 56, 56), new TimePeriod(12, 56, 56), true},
        };

        [TestMethod]
        [DynamicData(nameof(MoreThanOrEqualDataSet))]
        public void MoreThanOrEqual(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1 >= time2, expected);
        }

        public static IEnumerable<object[]> MoreThanOrEqualDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(12), new TimePeriod(13), false},
            new object[] {new TimePeriod(130), new TimePeriod(10), true},
            new object[] {new TimePeriod(20, 20), new TimePeriod(20, 21), false},
            new object[] {new TimePeriod(18, 51), new TimePeriod(18, 50), true},
            new object[] {new TimePeriod(12, 40, 41), new TimePeriod(12, 40, 42), false},
            new object[] {new TimePeriod(9, 10, 11), new TimePeriod(9, 10, 10), true},
            new object[] {new TimePeriod(21, 34, 55), new TimePeriod(21, 34, 55), true},
        };

        [TestMethod]
        [DynamicData(nameof(LessThanOrEqualDataSet))]
        public void LessThanOrEqual(TimePeriod time1, TimePeriod time2, bool expected)
        {
            Assert.AreEqual(time1 <= time2, expected);
        }

        public static IEnumerable<object[]> LessThanOrEqualDataSet => new List<object[]>
        {
            new object[] {new TimePeriod(9), new TimePeriod(8), false},
            new object[] {new TimePeriod(22), new TimePeriod(23), true},
            new object[] {new TimePeriod(210, 10), new TimePeriod(21, 9), false},
            new object[] {new TimePeriod(13, 50), new TimePeriod(13, 51), true},
            new object[] {new TimePeriod(15, 25, 25), new TimePeriod(15, 25, 24), false},
            new object[] {new TimePeriod(1, 17, 57), new TimePeriod(1, 17, 58), true},
            new object[] {new TimePeriod(23, 59, 59), new TimePeriod(23, 59, 59), true},
        };

        [TestMethod]
        [DynamicData(nameof(SortDataSet))]
        public void sort(List<TimePeriod> times, string[] expecteds)
        {
            times.Sort();

            for (int i = 0; i < expecteds.Length; i++)
            {
                Assert.AreEqual(times[i].ToString(), expecteds[i]);
            }
        }

        public static IEnumerable<object[]> SortDataSet => new List<object[]>
        {
            new object[] { new List<TimePeriod> { new TimePeriod(9), new TimePeriod(7), new TimePeriod(8), new TimePeriod(1) }, new string[] { "09:00:00", "08:00:00", "07:00:00", "01:00:00" } },
            new object[] { new List<TimePeriod> { new TimePeriod(1), new TimePeriod(23), new TimePeriod(3), new TimePeriod(1), new TimePeriod(0) }, new string[] { "23:00:00", "03:00:00", "01:00:00", "01:00:00", "00:00:00" } },
            new object[] { new List<TimePeriod> { new TimePeriod(23, 31), new TimePeriod(9, 41), new TimePeriod(0, 00), new TimePeriod(230, 59), new TimePeriod(230, 59) }, new string[] { "230:59:00", "230:59:00", "23:31:00", "09:41:00", "00:00:00" } },
            new object[] {
                    new List<TimePeriod> { new TimePeriod(10, 32, 12), new TimePeriod(312, 25, 9), new TimePeriod(0, 0, 0), new TimePeriod(23, 59, 58), new TimePeriod(0, 0, 0), new TimePeriod(23, 59, 59) },
                    new string[] { "312:25:09", "23:59:59", "23:59:58", "10:32:12", "00:00:00", "00:00:00" }
            },
        };
    }
}
