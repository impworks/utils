using System;
using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for StartsWithPart methods.
    /// </summary>
    [TestFixture]
    public class StringExtensions_StartsWithPart
    {
        [Test]
        public void StartsWithPath_returns_true_if_starts_with_part()
        {
            Assert.IsTrue("hello world".StartsWithPart("hello there", 5));
        }

        [Test]
        public void StartsWithPath_returns_false_if_does_not_start_with_part()
        {
            Assert.IsFalse("hello world".StartsWithPart("test there", 5));
        }

        [Test]
        public void StartsWithPath_returns_true_if_both_strings_are_shorter_but_equal()
        {
            Assert.IsTrue("hello".StartsWithPart("hello", 10));
        }

        [Test]
        public void StartsWithPath_returns_false_if_any_string_is_shorter_but_not_equal()
        {
            Assert.IsFalse("hello".StartsWithPart("test", 10));
        }

        [Test]
        public void StartsWithPath_is_case_sensitive_by_default()
        {
            Assert.IsFalse("hello world".StartsWithPart("HELLO there", 5));
        }

        [Test]
        public void StartsWithPath_ignores_case_if_flag_is_specified()
        {
            Assert.IsTrue("hello world".StartsWithPart("HELLO there", 5, true));
        }

        [Test]
        [TestCase(null, null, true)]
        [TestCase(null, "a", false)]
        [TestCase("a", null, false)]
        public void StartsWithPath_handles_nulls(string left, string right, bool result)
        {
            Assert.That(result, Is.EqualTo(left.StartsWithPart(right, 5)));
        }

        [Test]
        public void StartsWithPart_throws_on_zero_compareLength()
        {
            Assert.Throws<ArgumentException>(() => "a".StartsWithPart("b", 0));
        }
    }
}
