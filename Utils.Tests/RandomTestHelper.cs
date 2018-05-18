using System;
using NUnit.Framework;

namespace Utils.Tests
{
    /// <summary>
    /// Testing utilities.
    /// </summary>
    public static class RandomTestHelper
    {
        private const int ATTEMPTS = 100;

        /// <summary>
        /// Ensures the function succeeds at least once in a while.
        /// </summary>
        public static void AtLeastOnce(Func<bool> attempt)
        {
            for (var i = 0; i < ATTEMPTS; i++)
            {
                if (attempt())
                    Assert.Pass();
            }

            Assert.Fail($"Failed after {ATTEMPTS} attempts.");
        }

        /// <summary>
        /// Ensures the function succeeds in all attempts.
        /// </summary>
        public static void Always(Func<bool> attempt)
        {
            for (var i = 0; i < ATTEMPTS; i++)
            {
                if (!attempt())
                    Assert.Fail($"Failed on {i} attempt.");
            }

            Assert.Pass();
        }
    }
}
