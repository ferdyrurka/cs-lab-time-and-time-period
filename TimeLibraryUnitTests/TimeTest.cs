using Microsoft.VisualStudio.TestTools.UnitTesting;
using TimeLibrary;

namespace TimeLibraryUnitTests
{
    [TestClass]
    public class TimeTest
    {
        [TestMethod]
        public void CreateByHourMinuteSecond()
        {
            Time time = new Time(12, 45, 12);

            Assert.AreEqual("12:45:12", time.ToString());
        }

        public void CreateByHourMinute()
        {
            Time time = new Time(15, 32);

            Assert.AreEqual("15:32:00", time.ToString());
        }

        public void CreateByHour()
        {
            Time time = new Time(17);

            Assert.AreEqual("17:00:00", time.ToString());
        }

        public void CreateByString()
        {
            Time time = new Time(12, 45, 12);

            Assert.AreEqual("12:45:12", time.ToString());
        }
    }
}
