using System;
using System.Linq;

namespace Grafft.TimeMan.Utility
{
    public static class UnitTestDetector
    {
        private static readonly string[] TestAssemblies = {
            "Microsoft.VisualStudio.QualityTools.UnitTestFramework",
            "xunit.core",
            "nunit.framework"
        };

        static UnitTestDetector()
        {
            IsInUnitTest = AppDomain.CurrentDomain.GetAssemblies()
                            .Any(a => TestAssemblies.Any(ta => a.FullName.StartsWith(ta)));
        }

        public static bool IsInUnitTest { get; private set; }
    }
}