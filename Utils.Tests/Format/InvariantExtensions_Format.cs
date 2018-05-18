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
            Assert.AreEqual("1.337", 1.337f.ToInvariantString());
        }

        [Test]
        public void ToInvariantString_formats_double()
        {
            Assert.AreEqual("1.337", 1.337.ToInvariantString());
        }
    }
}
