using System;
using Impworks.Utils.Url;
using NUnit.Framework;

namespace Utils.Tests.Url
{
    /// <summary>
    /// Tests for UrlHelper.
    /// </summary>
    [TestFixture]
    public class UrlHelper_Combine
    {
        [Test]
        public void Combine_collapses_forward_slashes()
        {
            Assert.AreEqual("http://a/b/c", UrlHelper.Combine("http://a/", "/b/", "/c").ToString());
        }

        [Test]
        public void Combine_collapses_backward_slashes()
        {
            Assert.AreEqual("http://a/b/c", UrlHelper.Combine("http://a/", @"\b\", @"\c").ToString());
        }

        [Test]
        public void Combine_adds_missing_slashes()
        {
            Assert.AreEqual("http://a/b/c", UrlHelper.Combine("http://a", "b", "c").ToString());
        }

        [Test]
        public void Combine_removes_trailing_slash()
        {
            Assert.AreEqual("http://a/b", UrlHelper.Combine("http://a", @"b/").ToString());
        }

        [Test]
        public void Combine_skips_nulls()
        {
            Assert.AreEqual("http://a/c", UrlHelper.Combine("http://a", null, "c").ToString());
        }

        [Test]
        public void Combine_skips_empty_parts()
        {
            Assert.AreEqual("http://a/c", UrlHelper.Combine("http://a", "", "c").ToString());
        }

        [Test]
        public void Combine_skips_whitespace_parts()
        {
            Assert.AreEqual("http://a/c", UrlHelper.Combine("http://a", "   ", "c").ToString());
        }

        [Test]
        public void Combine_accepts_empty_parts_array()
        {
            Assert.AreEqual("http://a/", UrlHelper.Combine("http://a").ToString());
        }
        
        [Test]
        public void Combine_throws_ArgumentNullException_on_null_authority()
        {
            Assert.Throws<ArgumentNullException>(() => UrlHelper.Combine(null));
        }

        [Test]
        public void Combine_throws_ArgumentNullException_on_empty_authority()
        {
            Assert.Throws<ArgumentNullException>(() => UrlHelper.Combine(""));
        }

        [Test]
        public void Combine_throws_ArgumentNullException_on_null_parts()
        {
            Assert.Throws<ArgumentNullException>(() => UrlHelper.Combine("http://123", (string[]) null));
        }
    }
}
