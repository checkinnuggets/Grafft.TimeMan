using System;

namespace Grafft.TimeMan.Clock
{
    public abstract class FakeClock : IClock
    {
        public abstract bool IsFake { get; protected set; }

        public abstract Func<DateTime> TimeProvider { get; set; }

        public DateTime Now
        {
            get
            {
                if (TimeProvider == null)
                    Reset();

                return TimeProvider();
            }
        }

        public DateTime Today => Now.Date;

        public void Set(DateTime newDateTime)
        {
            Set(() => newDateTime);
        }

        public void Set(Func<DateTime> newDateTimeProvider)
        {
            TimeProvider = newDateTimeProvider;
            IsFake = true;
        }

        public void Reset()
        {
            TimeProvider = () => DateTime.Now;
            IsFake = false;
        }
    }
}