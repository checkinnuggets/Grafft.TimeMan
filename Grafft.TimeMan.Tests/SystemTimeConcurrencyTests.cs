using System;
using System.Threading;
using System.Threading.Tasks;
using Grafft.TimeMan.Clock;
using NUnit.Framework;

namespace Grafft.TimeMan.Tests
{
    public class SystemTimeConcurrencyTests
    {
        [Test]
        public void SettingTimeOnSeperateThreadsDoesntAffeactEachOther()
        {
            var fakeClock = TimeProvider.Clock as FakeClock;
            
            // just initialise to arbitrary value
            var result1 = DateTime.MaxValue; 
            var result2 = DateTime.MaxValue;

            var testDate1 = DateTime.Parse("2001-01-01 01:01:01");
            Action action1 = () =>
            {
                fakeClock.Set(testDate1);
                Thread.Sleep(250);          // short delay this thread, so the second one will set the value before this one sets it's result
                result1 = fakeClock.Now;
            };

            var testDate2 = DateTime.Parse("2002-02-02 02:02:02");
            Action action2 = () =>
            {
                fakeClock.Set(testDate2);
                // no delay on this thread
                result2 = fakeClock.Now;
            };

            var task1 = Task.Run(action1);
            var task2 = Task.Run(action2);

            Task.WaitAll(task1, task2);

            Assert.AreEqual(testDate1, result1);
            Assert.AreEqual(testDate2, result2);

            fakeClock.Reset();
        }

    }
}
