using System;
using Impworks.Utils.Comparisons;
using NUnit.Framework;

namespace Utils.Tests.Comparisons
{
    /// <summary>
    /// Tests for CompareHelper.Min.
    /// </summary>
    [TestFixture]
    public class CompareHelper_Min
    {
        [Test]
        public void Returns_min_of_two_strings()
        {
            Assert.That(CompareHelper.Min("a", "b"), Is.EqualTo("a"));
        }

        [Test]
        public void Returns_min_of_many_strings()
        {
            Assert.That(CompareHelper.Min("a", "b", "z", "_", "y"), Is.EqualTo("_"));
        }

        [Test]
        public void Returns_min_of_two_dates()
        {
            var a = DateTime.Parse("2023-01-01");
            var b = DateTime.Parse("2023-02-01");
            Assert.That(CompareHelper.Min(a, b), Is.EqualTo(a));
        }

        [Test]
        public void Returns_min_of_many_dates()
        {
            var dates = new[]
            {
                DateTime.Parse("2023-01-01"),
                DateTime.Parse("2023-02-01"),
                DateTime.Parse("2021-10-12"),
                DateTime.Parse("2022-07-11"),
            };
            Assert.That(CompareHelper.Min(dates), Is.EqualTo(dates[2]));
        }

        [Test]
        public void Returns_single_item()
        {
            Assert.That(CompareHelper.Min("a"), Is.EqualTo("a"));
        }

        [Test]
        public void Throws_exception_for_empty_array()
        {
            Assert.Throws<ArgumentException>(() => CompareHelper.Min<int>());
        }
    }
}
