using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    /// <summary>
    /// Tests for StringHelper.Coalesce.
    /// </summary>
    [TestFixture]
    public class StringHelper_Coalesce
    {
        [Test]
        public void Coalesce_skips_null_strings()
        {
            Assert.That(StringHelper.Coalesce(null, null, "test"), Is.EqualTo("test"));
        }

        [Test]
        public void Coalesce_skips_empty_strings()
        {
            Assert.That(StringHelper.Coalesce("", "", "test"), Is.EqualTo("test"));
        }

        [Test]
        public void Coalesce_returns_first_non_null()
        {
            Assert.That(StringHelper.Coalesce("test", "hello"), Is.EqualTo("test"));
        }

        [Test]
        public void Coalesce_returns_null_if_all_are_null()
        {
            Assert.IsNull(StringHelper.Coalesce(null, null));
        }
        
        [Test]
        public void Coalesce_returns_null_if_all_are_empty()
        {
            Assert.IsNull(StringHelper.Coalesce("", ""));
        }
    }
}
