using System;
using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for EndsWithPart methods.
    /// </summary>
    [TestFixture]
    public class StringExtensions_EndsWithPart
    {
        [Test]
        public void EndsWithPart_returns_true_if_starts_with_part()
        {
            Assert.IsTrue("hello world".EndsWithPart("test world", 5));
        }

        [Test]
        public void EndsWithPart_returns_false_if_does_not_start_with_part()
        {
            Assert.IsFalse("hello world".EndsWithPart("test there", 5));
        }

        [Test]
        public void EndsWithPart_returns_true_if_both_strings_are_shorter_but_equal()
        {
            Assert.IsTrue("hello".EndsWithPart("hello", 10));
        }

        [Test]
        public void EndsWithPart_returns_false_if_any_string_is_shorter_but_not_equal()
        {
            Assert.IsFalse("hello".EndsWithPart("test", 10));
        }

        [Test]
        public void EndsWithPart_is_case_sensitive_by_default()
        {
            Assert.IsFalse("hello world".EndsWithPart("hello WORLD", 5));
        }

        [Test]
        public void EndsWithPart_ignores_case_if_flag_is_specified()
        {
            Assert.IsTrue("hello world".EndsWithPart("hello WORLD", 5, true));
        }

        [Test]
        [TestCase(null, null, true)]
        [TestCase(null, "a", false)]
        [TestCase("a", null, false)]
        public void EndsWithPart_handles_nulls(string left, string right, bool result)
        {
            Assert.That(result, Is.EqualTo(left.EndsWithPart(right, 5)));
        }

        [Test]
        public void EndsWithPart_throws_on_zero_compareLength()
        {
            Assert.Throws<ArgumentException>(() => "a".EndsWithPart("b", 0));
        }
    }
}
