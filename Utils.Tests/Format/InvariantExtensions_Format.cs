using Impworks.Utils.Format;
using NUnit.Framework;

namespace Utils.Tests.Format
{
    /// <summary>
    /// InvariantExtensions helpers.
    /// </summary>
    [TestFixture]
    public class InvariantExtensions_Format
    {
        [Test]
        public void ToInvariantString_formats_float()
        {
            Assert.That(1.337f.ToInvariantString(), Is.EqualTo("1.337"));
        }

        [Test]
        public void ToInvariantString_formats_double()
        {
            Assert.That(1.337.ToInvariantString(), Is.EqualTo("1.337"));
        }
    }
}
