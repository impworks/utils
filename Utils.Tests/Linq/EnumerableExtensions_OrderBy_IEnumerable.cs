using System.Collections.Generic;
using System.Linq;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.OrderBy's IEnumerable overrides.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_OrderBy_IEnumerable
    {
        private IEnumerable<SampleObject> GetSampleObjects()
        {
            yield return new SampleObject(3, "hello");
            yield return new SampleObject(1, "world");
            yield return new SampleObject(2, "abra");
        }

        [Test]
        public void OrderBy_orders_ascending_when_flag_is_false()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Value, false).Select(x => x.Str);

            Assert.That(result, Is.EqualTo(new [] { "world", "abra", "hello" }));
        }

        [Test]
        public void OrderBy_orders_descending_when_flag_is_true()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Value, true).Select(x => x.Str);

            Assert.That(result, Is.EqualTo(new [] { "hello", "abra", "world" }));
        }

        [Test]
        public void ThenBy_orders_ascending_when_flag_is_false()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Str.Length, false)
                             .ThenBy(x => x.Value, false)
                             .Select(x => x.Str);

            Assert.That(result, Is.EqualTo(new [] { "abra", "world", "hello" }));
        }

        [Test]
        public void ThenBy_orders_ascending_when_flag_is_true()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(x => x.Str.Length, false)
                             .ThenBy(x => x.Value, true)
                             .Select(x => x.Str);

            Assert.That(result, Is.EqualTo(new [] { "abra", "hello", "world" }));
        }
    }
}
