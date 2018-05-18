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
            Assert.AreEqual("Test", "Test".ValueOrNull());
        }

        [Test]
        public void ValueOrNull_returns_value_for_whitespace_string_if_flag_is_enabled()
        {
            Assert.AreEqual("   ", "   ".ValueOrNull(allowWhitespace: true));
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
