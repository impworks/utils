using System.Linq;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.OrderBy's IQueryable overrides.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_OrderBy_IQueryable
    {
        private IQueryable<SampleObject> GetSampleObjects()
        {
            return new[]
                {
                    new SampleObject(3, "hello"),
                    new SampleObject(1, "world"),
                    new SampleObject(2, "abra")
                }
                .AsQueryable();
        }

        [Test]
        public void OrderBy_orders_ascending_when_flag_is_false()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Value, false).Select(x => x.Str);

            Assert.AreEqual(new[] {"world", "abra", "hello"}, result);
        }

        [Test]
        public void OrderBy_orders_descending_when_flag_is_true()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Value, true).Select(x => x.Str);

            Assert.AreEqual(new[] {"hello", "abra", "world"}, result);
        }

        [Test]
        public void ThenBy_orders_ascending_when_flag_is_false()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Str.Length, false)
                             .ThenBy(x => x.Value, false)
                             .Select(x => x.Str);

            Assert.AreEqual(new[] {"abra", "world", "hello"}, result);
        }

        [Test]
        public void ThenBy_orders_ascending_when_flag_is_true()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Str.Length, false)
                             .ThenBy(x => x.Value, true)
                             .Select(x => x.Str);

            Assert.AreEqual(new[] {"abra", "hello", "world"}, result);
        }
    }
}
