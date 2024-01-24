using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for StringExtensions.ValueOrNull.
    /// </summary>
    [TestFixture]
    public class StringExtensions_ValueOrNull
    {
        [Test]
        public void ValueOrNull_returns_value_for_non_empty_string()
        {
            Assert.That("Test".ValueOrNull(), Is.EqualTo("Test"));
        }

        [Test]
        public void ValueOrNull_returns_value_for_whitespace_string_if_flag_is_enabled()
        {
            Assert.That("   ".ValueOrNull(allowWhitespace: true), Is.EqualTo("   "));
        }

        [Test]
        public void ValueOrNull_returns_null_for_whitespace_string()
        {
            Assert.IsNull("   ".ValueOrNull());
        }
        
        [Test]
        public void ValueOrNull_returns_null_for_empty_string()
        {
            Assert.IsNull("".ValueOrNull());
        }
        
        [Test]
        public void ValueOrNull_returns_null_for_null_string()
        {
            Assert.IsNull((null as string).ValueOrNull());
        }
    }
}
