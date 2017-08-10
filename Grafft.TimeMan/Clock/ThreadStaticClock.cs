using System;

namespace Grafft.TimeMan.Clock
{
    public class ThreadStaticClock : FakeClock
    {
        [ThreadStatic]
        private static Func<DateTime> _threadStaticTimeProvider;

        [ThreadStatic]
        private static bool _isFake;

        public override bool IsFake { get { return _isFake; } protected set { _isFake = value; } }

        public override Func<DateTime> TimeProvider
        {
            get { return _threadStaticTimeProvider; }
            set { _threadStaticTimeProvider = value; }
        }
    }
}