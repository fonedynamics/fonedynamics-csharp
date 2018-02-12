using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoneDynamics.Extensions;
using NUnit.Framework;

namespace FoneDynamics.Tests.Extensions
{
    [TestFixture]
    public class UnixDateTimeExtensionsTests
    {
        [TestCase]
        public void ToUnixTime_WithUtcDate_ConvertsTimeCorrectly()
        {
            DateTime utcDate = new DateTime(2018, 2, 10, 9, 59, 20);
            long unixTime = utcDate.ToUnixTime();
            long expectedTime = 1518256760;
            Assert.AreEqual(expectedTime, unixTime);
        }

        [TestCase]
        public void FromUnixTime_ToUtcDate_ConvertsTimeCorrectly()
        {
            long unixTime = 1518256760;
            DateTime utcDate = unixTime.FromUnixTime();

            DateTime expectedTime = new DateTime(2018, 2, 10, 9, 59, 20);
            Assert.AreEqual(expectedTime, utcDate);
        }
    }
}
