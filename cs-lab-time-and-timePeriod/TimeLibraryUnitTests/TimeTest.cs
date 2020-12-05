using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using TimeLibrary;

namespace TimeLibraryUnitTests
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        [DataRow(0, 0, 0, "00:00:00")]
        [DataRow(09, 25, 16, "09:25:16")]
        [DataRow(10, 3, 44, "10:03:44")]
        [DataRow(11, 32, 4, "11:32:04")]
        [DataRow(1, 3, 6, "01:03:06")]
        [DataRow(12, 33, 46, "12:33:46")]
        [DataRow(23, 59, 59, "23:59:59")]
        public void CreateByHourMinuteSecond(int hour, int minute, int second, string expected)
        {
            Time time = new Time(Convert.ToByte(hour), Convert.ToByte(minute), Convert.ToByte(second));

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow(0, 0, "00:00:00")]
        [DataRow(12, 43, "12:43:00")]
        [DataRow(10, 9, "10:09:00")]
        [DataRow(9, 59, "09:59:00")]
        [DataRow(1, 7, "01:07:00")]
        [DataRow(23, 59, "23:59:00")]
        [DataRow(0, 59, "00:59:00")]
        public void CreateByHourMinute(int hour, int minute, string expected)
        {
            Time time = new Time(Convert.ToByte(hour), Convert.ToByte(minute));

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow(0, "00:00:00")]
        [DataRow(4, "04:00:00")]
        [DataRow(15, "15:00:00")]
        [DataRow(23, "23:00:00")]
        public void CreateByHour(int hour, string expected)
        {
            Time time = new Time(Convert.ToByte(hour));

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
        [DataRow("23:59:59", "23:59:59")]
        [DataRow("21:41:12", "21:41:12")]
        [DataRow("9:41:12", "09:41:12")]
        [DataRow("21:4:12", "21:04:12")]
        [DataRow("21:45:2", "21:45:02")]
        public void CreateByString(string timeInString, string expected)
        {
            Time time = new Time(timeInString);

            Assert.AreEqual(expected, time.ToString());
        }

        [TestMethod]
        [DataRow(-1)]
        [DataRow(-100)]
        [DataRow(25)]
        [DataRow(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void LessOrMoreThanHour(byte hour)
        {
            new Time(hour);
        }

        [TestMethod]
        [DataRow(-60)]
        [DataRow(-100)]
        [DataRow(60)]
        [DataRow(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void LessOrMoreThanMinute(byte minute)
        {
            new Time(21, minute);
        }

        [TestMethod]
        [DataRow(-60)]
        [DataRow(-100)]
        [DataRow(60)]
        [DataRow(100)]
        [ExpectedException(typeof(ArgumentException))]
        public void LessOrMoreThanSecond(byte second)
        {
            new Time(15, 20, second);
        }

        [TestMethod]
        [DynamicData(nameof(MoreThanDataSet))]
        public void MoreThan(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1 > time2, expected);
        }

        public static IEnumerable<object[]> MoreThanDataSet => new List<object[]>
        {
            new object[] {new Time(12), new Time(13), false},
            new object[] {new Time(13), new Time(12), true},
            new object[] {new Time(20, 20), new Time(20, 21), false},
            new object[] {new Time(18, 51), new Time(18, 50), true},
            new object[] {new Time(12, 40, 41), new Time(12, 40, 42), false},
            new object[] {new Time(9, 10, 11), new Time(9, 10, 10), true},
        };

        [TestMethod]
        [DynamicData(nameof(LessThanDataSet))]
        public void LessThan(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1 < time2, expected);
        }

        public static IEnumerable<object[]> LessThanDataSet => new List<object[]>
        {
            new object[] {new Time(9), new Time(8), false},
            new object[] {new Time(22), new Time(23), true},
            new object[] {new Time(21, 10), new Time(21, 9), false},
            new object[] {new Time(13, 50), new Time(13, 51), true},
            new object[] {new Time(15, 25, 25), new Time(15, 25, 24), false},
            new object[] {new Time(1, 17, 57), new Time(1, 17, 58), true},
        };

        [TestMethod]
        [DynamicData(nameof(EqualOperatorDataSet))]
        public void EqualOperator(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1 == time2, expected);
        }

        public static IEnumerable<object[]> EqualOperatorDataSet => new List<object[]>
        {
            new object[] {new Time(9), new Time(8), false},
            new object[] {new Time(22), new Time(22), true},
            new object[] {new Time(1, 10), new Time(12, 2), false},
            new object[] {new Time(13, 50), new Time(13, 50), true},
            new object[] {new Time(21, 7, 32), new Time(14, 11, 9), false},
            new object[] {new Time(15, 25, 25), new Time(15, 25, 25), true},
        };

        [TestMethod]
        [DynamicData(nameof(NotEqualOperatorDataSet))]
        public void NotEqualOperator(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1 != time2, expected);
        }

        public static IEnumerable<object[]> NotEqualOperatorDataSet => new List<object[]>
        {
            new object[] {new Time(9), new Time(8), true},
            new object[] {new Time(22), new Time(22), false},
            new object[] {new Time(1, 10), new Time(12, 2), true},
            new object[] {new Time(13, 50), new Time(13, 50), false},
            new object[] {new Time(21, 7, 32), new Time(14, 11, 9), true},
            new object[] {new Time(15, 25, 25), new Time(15, 25, 25), false},
        };

        [TestMethod]
        [DynamicData(nameof(EqualDataSet))]
        public void Equal(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1.Equals(time2), expected);
        }

        public static IEnumerable<object[]> EqualDataSet => new List<object[]>
        {
            new object[] {new Time(23), new Time(9), false},
            new object[] {new Time(12), new Time(12), true},
            new object[] {new Time(12, 15), new Time(13, 52), false},
            new object[] {new Time(16, 59), new Time(16, 59), true},
            new object[] {new Time(23, 27, 17), new Time(12, 21, 39), false},
            new object[] {new Time(12, 56, 56), new Time(12, 56, 56), true},
        };

        [TestMethod]
        [DynamicData(nameof(MoreThanOrEqualDataSet))]
        public void MoreThanOrEqual(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1 >= time2, expected);
        }

        public static IEnumerable<object[]> MoreThanOrEqualDataSet => new List<object[]>
        {
            new object[] {new Time(12), new Time(13), false},
            new object[] {new Time(13), new Time(12), true},
            new object[] {new Time(20, 20), new Time(20, 21), false},
            new object[] {new Time(18, 51), new Time(18, 50), true},
            new object[] {new Time(12, 40, 41), new Time(12, 40, 42), false},
            new object[] {new Time(9, 10, 11), new Time(9, 10, 10), true},
            new object[] {new Time(21, 34, 55), new Time(21, 34, 55), true},
        };

        [TestMethod]
        [DynamicData(nameof(LessThanOrEqualDataSet))]
        public void LessThanOrEqual(Time time1, Time time2, bool expected)
        {
            Assert.AreEqual(time1 <= time2, expected);
        }

        public static IEnumerable<object[]> LessThanOrEqualDataSet => new List<object[]>
        {
            new object[] {new Time(9), new Time(8), false},
            new object[] {new Time(22), new Time(23), true},
            new object[] {new Time(21, 10), new Time(21, 9), false},
            new object[] {new Time(13, 50), new Time(13, 51), true},
            new object[] {new Time(15, 25, 25), new Time(15, 25, 24), false},
            new object[] {new Time(1, 17, 57), new Time(1, 17, 58), true},
            new object[] {new Time(23, 59, 59), new Time(23, 59, 59), true},
        };

        [TestMethod]
        [DynamicData(nameof(SortDataSet))]
        public void sort(List<Time> times, string[] expecteds)
        {
            times.Sort();

            for (int i = 0; i < expecteds.Length; i++)
            {
                Assert.AreEqual(times[i].ToString(), expecteds[i]);
            }
        }

        public static IEnumerable<object[]> SortDataSet => new List<object[]>
        {
            new object[] { new List<Time> { new Time(9), new Time(7), new Time(8), new Time(1) }, new string[] { "09:00:00", "08:00:00", "07:00:00", "01:00:00" } },
            new object[] { new List<Time> { new Time(1), new Time(23), new Time(3), new Time(1), new Time(0) }, new string[] { "23:00:00", "03:00:00", "01:00:00", "01:00:00", "00:00:00" } },
            new object[] { new List<Time> { new Time(23, 31), new Time(9, 41), new Time(0, 00), new Time(23, 59), new Time(23, 59) }, new string[] { "23:59:00", "23:59:00", "23:31:00", "09:41:00", "00:00:00" } },
            new object[] {
                    new List<Time> { new Time(10, 32, 12), new Time(3, 25, 9), new Time(0, 0, 0), new Time(23, 59, 58), new Time(0, 0, 0), new Time(23, 59, 59) },
                    new string[] { "23:59:59", "23:59:58", "10:32:12", "03:25:09", "00:00:00", "00:00:00" }
            },
        };

        [TestMethod]
        [DynamicData(nameof(PlusDataSet))]
        public void PlusOperator(Time time, TimePeriod timePeriod, string expected)
        {
            Assert.AreEqual((time + timePeriod).ToString(), expected);
        }

        [TestMethod]
        [DynamicData(nameof(PlusDataSet))]
        public void PlusStaticMethodOperator(Time time, TimePeriod timePeriod, string expected)
        {
            Assert.AreEqual(Time.Plus(time, timePeriod).ToString(), expected);
        }

        [TestMethod]
        [DynamicData(nameof(PlusDataSet))]
        public void PlusTimeObjectOperator(Time time, TimePeriod timePeriod, string expected)
        {
            Assert.AreEqual(time.Plus(timePeriod).ToString(), expected);
        }

        public static IEnumerable<object[]> PlusDataSet => new List<object[]>
        {
            new object[] {new Time(9), new TimePeriod(8), "17:00:00"},
            new object[] {new Time(22), new TimePeriod(23), "21:00:00"},
            new object[] {new Time(21, 10), new TimePeriod(21, 9), "18:19:00"},
            new object[] {new Time(13, 50), new TimePeriod(0, 51), "14:41:00"},
            new object[] {new Time(15, 25, 25), new TimePeriod(1, 25, 24), "16:50:49"},
            new object[] {new Time(1, 17, 59), new TimePeriod(22, 42, 59), "00:00:58"},
            new object[] {new Time(20, 59, 59), new TimePeriod(230, 1, 1), "11:01:00"},
            new object[] {new Time(20, 59, 59), new TimePeriod(230, 0, 1), "11:00:00"},
            new object[] {new Time(23, 59, 00), new TimePeriod(0, 0, 59), "23:59:59"},
            new object[] {new Time(23, 59, 59), new TimePeriod(0, 2, 0), "00:01:59"},
        };

        [TestMethod]
        [DynamicData(nameof(MinusDataSet))]
        public void MinusOperator(Time time, TimePeriod timePeriod, string expected)
        {
            Assert.AreEqual((time - timePeriod).ToString(), expected);
        }

        [TestMethod]
        [DynamicData(nameof(MinusDataSet))]
        public void MinusStaticMethodOperator(Time time, TimePeriod timePeriod, string expected)
        {
            Assert.AreEqual(Time.Minus(time, timePeriod).ToString(), expected);
        }

        [TestMethod]
        [DynamicData(nameof(MinusDataSet))]
        public void MinusTimeObjectOperator(Time time, TimePeriod timePeriod, string expected)
        {
            Assert.AreEqual(time.Minus(timePeriod).ToString(), expected);
        }

        public static IEnumerable<object[]> MinusDataSet => new List<object[]>
        {
            new object[] {new Time(9), new TimePeriod(8), "01:00:00"},
            new object[] {new Time(23), new TimePeriod(23), "00:00:00"},
            new object[] {new Time(23), new TimePeriod(24), "23:00:00"},
            new object[] {new Time(21, 10), new TimePeriod(21, 9), "00:01:00"},
            new object[] {new Time(13, 50), new TimePeriod(0, 51), "12:59:00"},
            new object[] {new Time(15, 25, 25), new TimePeriod(1, 25, 24), "14:00:01"},
            new object[] {new Time(1, 17, 59), new TimePeriod(22, 42, 59), "21:25:00"},
            new object[] {new Time(20, 59, 59), new TimePeriod(49, 59, 1), "19:00:58"},
            new object[] {new Time(20, 59, 59), new TimePeriod(48, 0, 59), "20:59:00"},
            new object[] {new Time(23, 59, 00), new TimePeriod(0, 0, 59), "23:58:01"},
            new object[] {new Time(23, 59, 59), new TimePeriod(0, 0, 59), "23:59:00"},
            new object[] {new Time(23, 59, 59), new TimePeriod(0, 59, 0), "23:00:59"},
            new object[] {new Time(23, 00, 59), new TimePeriod(0, 59, 0), "22:01:59"},
        };
    }
}
