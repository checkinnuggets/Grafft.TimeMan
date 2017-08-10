using System;

namespace Grafft.TimeMan.Clock
{
    public interface IClock
    {
        DateTime Now { get; }

        DateTime Today { get; }
    }
}