using System.Collections.Generic;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.AddRange.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_AddRange
    {
        [Test]
        public void AddRange_adds_values()
        {
            var list = new List<int> {1, 2, 3} as ICollection<int>;
            list.AddRange(new [] { 4, 5 });

            Assert.That(list, Is.EqualTo(new [] { 1, 2, 3, 4, 5 }));
        }
    }
}
