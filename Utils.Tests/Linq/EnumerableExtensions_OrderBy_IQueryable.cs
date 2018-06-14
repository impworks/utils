using System;
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
        public void OrderBy_orders_by_property_name()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(nameof(SampleObject.Value), false)
                             .Select(x => x.Str);

            Assert.AreEqual(new[] {"world", "abra", "hello"}, result);
        }

        [Test]
        public void OrderBy_orders_by_field_name()
        {
            var objs = new[]
            {
                new SampleObject { Value = 1, Field = "hello" },
                new SampleObject { Value = 2, Field = "world" },
                new SampleObject { Value = 3, Field = "abra" },
            };

            var result = objs.AsQueryable()
                             .OrderBy(nameof(SampleObject.Field), false)
                             .Select(x => x.Value);

            Assert.AreEqual(new[] {3, 1, 2}, result);
        }

        [Test]
        public void OrderBy_orders_by_property_name_descending_when_flag_is_true()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy(nameof(SampleObject.Value), true)
                             .Select(x => x.Str);

            Assert.AreEqual(new[] {"hello", "abra", "world"}, result);
        }

        [Test]
        public void OrderBy_throws_ArgumentException_on_missing_property()
        {
            Assert.Throws<ArgumentException>(() => GetSampleObjects().OrderBy("Blabla", true));
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

        [Test]
        public void ThenBy_orders_by_property_name()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy("Str.Length", true)
                             .ThenBy("Str", false)
                             .Select(x => x.Str);

            Assert.AreEqual(new[] {"hello", "world", "abra"}, result);
        }

        [Test]
        public void ThenBy_orders_by_property_name_descending_when_flag_is_true()
        {
            var objs = GetSampleObjects();

            var result = objs.OrderBy("Str.Length", true)
                             .ThenBy("Str", true)
                             .Select(x => x.Str);

            Assert.AreEqual(new[] {"world", "hello", "abra"}, result);
        }
    }
}
