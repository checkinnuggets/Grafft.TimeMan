using System;
using Grafft.TimeMan.Clock;
using NUnit.Framework;

namespace Grafft.TimeMan.Tests
{
    public class ClockTests
    {
        [Test]
        public void ClockStateChangeTest()
        {
            // done in a single test, because it's a static class
            var testDate = DateTime.Parse("2012-03-04");

            Assert.False(TimeProvider.IsFake);                  // starts off not fake

            ((FakeClock)TimeProvider.Clock).Set(testDate);      // set a date
            Assert.True(TimeProvider.IsFake);                   // is fake
            Assert.AreEqual(testDate, TimeProvider.Clock.Now);     // returns date set

            ((FakeClock)TimeProvider.Clock).Reset();            // reset
            Assert.False(TimeProvider.IsFake);                  // not fake
            Assert.AreNotEqual(testDate, TimeProvider.Clock.Now);  // not returning fake date
        }
    }
}
 