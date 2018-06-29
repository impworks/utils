using NUnit.Framework;
using System.Collections.Generic;
using Impworks.Utils.Dictionary;

namespace Utils.Tests.Dictionary
{
    /// <summary>
    /// Tests for DictionaryHelper.
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
        public void TryGetNullableValue_returns_value_for_existing_keys()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.AreEqual(2, dict.TryGetNullableValue("a"));
        }
        
        [Test]
        public void TryGetNullableValue_returns_default_for_missing_keys()
        {
            var dict = new Dictionary<string, int>
            {
                ["hello"] = 1,
                ["a"] = 2
            };

            Assert.AreEqual(null, dict.TryGetNullableValue("bla"));
        }
    }
}
