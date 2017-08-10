using Grafft.TimeMan.Clock;
using Grafft.TimeMan.Utility;

namespace Grafft.TimeMan
{
    public static class TimeProvider
    {
        public static readonly IClock Clock;

        static TimeProvider()
        {
#if (DEBUG)
            if (UnitTestDetector.IsInUnitTest)
                Clock = new ThreadStaticClock();
            else
                Clock = new StaticClock();
#else
            Clock = new RealClock();    
#endif
        }

        public static bool IsFake
        {
            get
            {
                var fakeClock = Clock as FakeClock;

                return fakeClock != null && fakeClock.IsFake;
            }
        }
    }
}
