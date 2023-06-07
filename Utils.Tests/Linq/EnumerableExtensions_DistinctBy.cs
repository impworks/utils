using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.DistinctBy.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_DistinctBy
    {
#if !NET6_0_OR_GREATER
        [Test]
        public void DistinctBy_filters_by_predicate()
        {
            var list = new [] {1, 2, 3, 4, 5};
            var result = list.DistinctBy(x => x % 2);

            Assert.AreEqual(new [] { 1, 2 }, result);
        }
#endif
    }
}
