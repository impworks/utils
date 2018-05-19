using System.Text.RegularExpressions;
using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for StringHelper.Transliterate.
    /// </summary>
    [TestFixture]
    public class StringHelper_Transliterate
    {
        [Test]
        public void Transliterate_transliterates_russian_characters()
        {
            var src = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            var result = StringHelper.Transliterate(src);

            Assert.IsTrue(Regex.IsMatch(src, "[а-я]"));
            Assert.IsFalse(Regex.IsMatch(result, "[а-я]"));
        }

        [Test]
        public void Transliterate_converts_uppercase_chars()
        {
            var src = "ПРИВЕТ";
            Assert.AreEqual("PRIVET", StringHelper.Transliterate(src));
        }

        [Test]
        public void Transliterate_converts_long_uppercase_chars_by_capitalization()
        {
            var src = "Шалом";
            Assert.AreEqual("Shalom", StringHelper.Transliterate(src));
        }

        [Test]
        public void Transliterate_ignores_english_characters()
        {
            var src = "abcdefghijklmnopqrstuvwxyz";

            Assert.AreEqual(src, StringHelper.Transliterate(src));
        }

        [Test]
        public void Transliterate_ignores_digits_and_few_special_chars()
        {
            var src = "1234567890-_.";

            Assert.AreEqual(src, StringHelper.Transliterate(src));
        }

        [Test]
        public void Transliterate_replaces_other_special_chars_to_fallback_char()
        {
            var src = "hello, world!";

            Assert.AreEqual("hello-world", StringHelper.Transliterate(src));
        }

        [Test]
        public void Transliterate_leaves_duplicates_fallback_char_in_middle_if_cleanOutput_is_false()
        {
            var src = "hello, world";

            Assert.AreEqual("hello--world", StringHelper.Transliterate(src, cleanOutput: false));
        }

        [Test]
        public void Transliterate_leaves_trailing_fallback_char_if_cleanOutput_is_false()
        {
            var src = "hello!";

            Assert.AreEqual("hello-", StringHelper.Transliterate(src, cleanOutput: false));
        }

        [Test]
        public void Transliterate_leaves_leading_fallback_char_if_cleanOutput_is_false()
        {
            var src = "~hello";

            Assert.AreEqual("-hello", StringHelper.Transliterate(src, cleanOutput: false));
        }

        [Test]
        public void Transliterate_uses_given_fallbackChar()
        {
            var src = "hello there, world";

            Assert.AreEqual("hello@@there@@world", StringHelper.Transliterate(src, fallbackChar: "@@"));
        }

        [Test]
        public void Transliterate_uses_safe_regex()
        {
            var src = "hello there, world";

            Assert.AreEqual("hello there- world", StringHelper.Transliterate(src, safeRegex: @"[a-z\s]"));
        }
    }
}
