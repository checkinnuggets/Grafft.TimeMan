using System;

namespace Grafft.TimeMan.Clock
{
    public class StaticClock : FakeClock
    {
        private static Func<DateTime> _staticTimeProvider;

        public override bool IsFake { get; protected set; }

        public override Func<DateTime> TimeProvider
        {
            get { return _staticTimeProvider; }
            set { _staticTimeProvider = value; }
        }
    }
}