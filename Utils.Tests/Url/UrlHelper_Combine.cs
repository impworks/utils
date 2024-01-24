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
            Assert.That(UrlHelper.Combine("http://a/", "/b/", "/c").ToString(), Is.EqualTo("http://a/b/c"));
        }

        [Test]
        public void Combine_collapses_backward_slashes()
        {
            Assert.That(UrlHelper.Combine("http://a/", @"\b\", @"\c").ToString(), Is.EqualTo("http://a/b/c"));
        }

        [Test]
        public void Combine_adds_missing_slashes()
        {
            Assert.That(UrlHelper.Combine("http://a", "b", "c").ToString(), Is.EqualTo("http://a/b/c"));
        }

        [Test]
        public void Combine_adds_missing_slashes_2()
        {
            Assert.That(UrlHelper.Combine("http://a/b", "c").ToString(), Is.EqualTo("http://a/b/c"));
        }

        [Test]
        public void Combine_adds_missing_slashes_3()
        {
            Assert.That(UrlHelper.Combine("http://a/b?", "c").ToString(), Is.EqualTo("http://a/c"));
        }

        [Test]
        public void Combine_removes_trailing_slash()
        {
            Assert.That(UrlHelper.Combine("http://a", @"b/").ToString(), Is.EqualTo("http://a/b"));
        }

        [Test]
        public void Combine_skips_nulls()
        {
            Assert.That(UrlHelper.Combine("http://a", null, "c").ToString(), Is.EqualTo("http://a/c"));
        }

        [Test]
        public void Combine_skips_empty_parts()
        {
            Assert.That(UrlHelper.Combine("http://a", "", "c").ToString(), Is.EqualTo("http://a/c"));
        }

        [Test]
        public void Combine_skips_whitespace_parts()
        {
            Assert.That(UrlHelper.Combine("http://a", "   ", "c").ToString(), Is.EqualTo("http://a/c"));
        }

        [Test]
        public void Combine_accepts_empty_parts_array()
        {
            Assert.That(UrlHelper.Combine("http://a").ToString(), Is.EqualTo("http://a/"));
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
            Assert.Throws<ArgumentNullException>(() => UrlHelper.Combine("http://123", null));
        }
    }
}
