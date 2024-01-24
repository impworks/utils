using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.JoinString.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_JoinString
    {
        [Test]
        public void JoinString_joins_with_separator()
        {
            Assert.That(new [] { "A", "B", "C" }.JoinString("&"), Is.EqualTo("A&B&C"));
        }

        [Test]
        public void JoinString_joins_with_empty_separator()
        {
            Assert.That(new [] { "A", "B", "C" }.JoinString(""), Is.EqualTo("ABC"));
        }

        [Test]
        public void JoinString_joins_with_null_separator()
        {
            Assert.That(new [] { "A", "B", "C" }.JoinString(null), Is.EqualTo("ABC"));
        }

        [Test]
        public void JoinString_returns_empty_string_on_empty_array()
        {
            Assert.That(new string[0].JoinString(""), Is.EqualTo(""));
        }
    }
}
