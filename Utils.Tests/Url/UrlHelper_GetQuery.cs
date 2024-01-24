using System;
using System.Collections.Generic;
using Impworks.Utils.Url;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Utils.Tests.Url
{
    /// <summary>
    /// Tests for UrlHelper.GetQuery method group.
    /// </summary>
    [TestFixture]
    class UrlHelper_GetQuery
    {
        [Test]
        public void GetQuery_accepts_anonymous_type()
        {
            var dict = new
            {
                A = 1,
                B = 2
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A=1&B=2"));
        }

        [Test]
        public void GetQuery_accepts_dictionary()
        {
            var dict = new Dictionary<string, object>
            {
                ["A"] = 1,
                ["B"] = 2
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A=1&B=2"));
        }

        [Test]
        public void GetQuery_accepts_JObject()
        {
            var dict = new JObject
            {
                ["A"] = 1,
                ["B"] = 2
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A=1&B=2"));
        }

        [Test]
        public void GetQuery_renders_array_elements()
        {
            var dict = new
            {
                A = new [] { 1, 2, 3 }
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A=1&A=2&A=3"));
        }

        [Test]
        public void GetQuery_renders_strings()
        {
            var dict = new
            {
                A = "hello",
                B = "world"
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A=hello&B=world"));
        }

        [Test]
        public void GetQuery_escapes_keys()
        {
            var dict = new JObject
            {
                ["A B"] = 1
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A%20B=1"));
        }

        [Test]
        public void GetQuery_escapes_values()
        {
            var dict = new JObject
            {
                ["A"] = "Hello/world"
            };
            Assert.That(UrlHelper.GetQuery(dict), Is.EqualTo("A=Hello%2Fworld"));
        }
        
        [Test]
        public void Combine_throws_ArgumentNullException_on_null_object()
        {
            Assert.Throws<ArgumentNullException>(() => UrlHelper.GetQuery(null));
        }

        [Test]
        public void Combine_throws_ArgumentNullException_on_null_props()
        {
            Assert.Throws<ArgumentNullException>(() => UrlHelper.GetQuery(null as IEnumerable<KeyValuePair<string, int>>));
        }
    }
}
