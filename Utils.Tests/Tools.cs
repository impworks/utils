using System;
using NUnit.Framework;

namespace Utils.Tests
{
    /// <summary>
    /// Testing utilities.
    /// </summary>
    public static class Tools
    {
        /// <summary>
        /// Ensures the function succeeds at least once in a while.
        /// </summary>
        public static void TestRandomized(Func<bool> attempt)
        {
            const int ATTEMPTS = 100;

            for (var i = 0; i < ATTEMPTS; i++)
            {
                if (attempt())
                    Assert.Pass();
            }

            Assert.Fail($"Failed after {ATTEMPTS} attempts.");
        }
    }
}
