using System.Collections.Generic;
using Impworks.Utils.Dictionary;
using NUnit.Framework;

namespace Utils.Tests.Dictionary
{
    /// <summary>
    /// Tests for DictionaryHelper.TryGetNullableValue.
    /// </summary>
    [TestFixture]
    public class DictionaryHelper_TryGetNullableValue
    {
        [Test]
        public void TryGetNullableValue_returns_value_for_existing_keys()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.That(dict.TryGetNullableValue("a"), Is.EqualTo(2));
        }

        [Test]
        public void TryGetNullableValue_returns_default_for_missing_keys()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.That(dict.TryGetNullableValue("bla"), Is.Null);
        }

        [Test]
        public void TryGetNullableValue_returns_default_for_null_as_single_elem()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.That(dict.TryGetNullableValue(null as string), Is.Null);
        }

        [Test]
        public void TryGetNullableValue_returns_default_for_null_as_array()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.That(dict.TryGetNullableValue(null as string[]), Is.Null);
        }

        [Test]
        public void TryGetNullableValue_accepts_list()
        {
            var dict = new Dictionary<int, int>
            {
                [1] = 13,
                [2] = 37
            };

            Assert.That(dict.TryGetNullableValue(3, 2, 1), Is.EqualTo(37));
        }

        [Test]
        public void TryGetNullableValue_with_list_returns_null_for_missing_keys()
        {
            var dict = new Dictionary<int, int>
            {
                [1] = 1,
                [2] = 2
            };

            Assert.That(dict.TryGetNullableValue(4, 5), Is.Null);
        }

        [Test]
        public void TryGetNullableValue_with_list_skips_null_keys()
        {
            var dict = new Dictionary<string, int>
            {
                ["a"] = 1,
                ["b"] = 2
            };

            Assert.That(dict.TryGetNullableValue(null, "b"), Is.EqualTo(2));
        }
    }
}
