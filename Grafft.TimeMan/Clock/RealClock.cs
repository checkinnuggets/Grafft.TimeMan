using System;

namespace Grafft.TimeMan.Clock
{
    public class RealClock : IClock
    {
        public DateTime Now => DateTime.Now;
        public DateTime Today => Now.Date;
    }
}