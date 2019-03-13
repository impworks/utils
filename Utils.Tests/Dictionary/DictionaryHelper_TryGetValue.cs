using NUnit.Framework;
using System.Collections.Generic;
using Impworks.Utils.Dictionary;

namespace Utils.Tests.Dictionary
{
    /// <summary>
    /// Tests for DictionaryHelper.TryGetValue.
    /// </summary>
    [TestFixture]
    public class DictionaryHelper_TryGetValue
    {
        [Test]
        public void TryGetValue_returns_value_for_existing_keys()
        {
            var dict = new Dictionary<string, string>
            {
                ["hello"] = "world",
                ["a"] = "b"
            };

            Assert.AreEqual("world", dict.TryGetValue("hello"));
        }

        [Test]
        public void TryGetValue_returns_null_for_missing_ref_types()
        {
            var dict = new Dictionary<string, string>
            {
                ["hello"] = "world",
                ["a"] = "b"
            };

            Assert.IsNull(dict.TryGetValue("bla"));
        }

        [Test]
        public void TryGetValue_returns_default_for_missing_value_types()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.AreEqual(0, dict.TryGetValue("bla"));
        }

        [Test]
        public void TryGetValue_accepts_list()
        {
            var dict = new Dictionary<int, int>
            {
                [1] = 13,
                [2] = 37
            };

            Assert.AreEqual(37, dict.TryGetValue(3, 2, 1));
        }

        [Test]
        public void TryGetValue_with_list_returns_default_for_missing_value_types()
        {
            var dict = new Dictionary<int, int>
            {
                [1] = 13,
                [2] = 37
            };

            Assert.AreEqual(0, dict.TryGetValue(4, 5));
        }

        [Test]
        public void TryGetValue_with_list_returns_null_for_missing_ref_types()
        {
            var dict = new Dictionary<int, string>
            {
                [1] = "foo",
                [2] = "bar"
            };

            Assert.AreEqual(null, dict.TryGetValue(4, 5));
        }

        [Test]
        public void TryGetValue_returns_default_on_null_key_as_single_elem()
        {
            var dict = new Dictionary<string, string>
            {
                ["a"] = "foo",
                ["b"] = "bar"
            };

            Assert.AreEqual(null, dict.TryGetValue(null as string));
        }

        [Test]
        public void TryGetValue_returns_default_on_null_key_as_array()
        {
            var dict = new Dictionary<string, string>
            {
                ["a"] = "foo",
                ["b"] = "bar"
            };

            Assert.AreEqual(null, dict.TryGetValue(null as string[]));
        }

        [Test]
        public void TryGetValue_skips_nulls_in_key_list()
        {
            var dict = new Dictionary<string, string>
            {
                ["a"] = "foo",
                ["b"] = "bar"
            };

            Assert.AreEqual("foo", dict.TryGetValue(null, null, "a"));
        }
    }
}
