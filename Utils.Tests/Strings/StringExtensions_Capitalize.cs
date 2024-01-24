using System;
using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for StringExtensions.Capitalize.
    /// </summary>
    [TestFixture]
    public class StringExtensions_Capitalize
    {
        [Test]
        public void Capitalize_converts_first_character_to_uppercase()
        {
            Assert.That("hello".Capitalize(), Is.EqualTo("Hello"));
        }

        [Test]
        public void Capitalize_converts_first_character_to_uppercase_in_russian()
        {
            Assert.That("привет".Capitalize(), Is.EqualTo("Привет"));
        }

        [Test]
        public void Capitalize_does_not_affect_special_chars()
        {
            Assert.That("123".Capitalize(), Is.EqualTo("123"));
        }

        [Test]
        public void Capitalize_does_not_affect_already_uppercase_chars()
        {
            Assert.That("TEST".Capitalize(), Is.EqualTo("TEST"));
        }

        [Test]
        public void Capitalize_does_not_affect_empty_strings()
        {
            Assert.That("".Capitalize(), Is.EqualTo(""));
        }
        
        [Test]
        public void Capitalize_throws_on_null_string()
        {
            Assert.Throws<ArgumentNullException>(() => (null as string).Capitalize());
        }
        
        [Test]
        public void Capitalize_throws_on_null_culture()
        {
            Assert.Throws<ArgumentNullException>(() => "hello".Capitalize(null));
        }
    }
}
