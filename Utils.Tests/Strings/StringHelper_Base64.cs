using Impworks.Utils.Strings;
using NUnit.Framework;

namespace Utils.Tests.Strings
{
    [TestFixture]
    public class StringHelper_Base64
    {
        [Test]
        public void Encode()
        {
            var src = "Hello world";
            var encoded = StringHelper.Base64Encode(src);

            Assert.That(encoded, Is.EqualTo("SGVsbG8gd29ybGQ="));
        }

        [Test]
        public void Decode()
        {
            var src = "SGVsbG8gd29ybGQ=";
            var encoded = StringHelper.Base64Decode(src);

            Assert.That(encoded, Is.EqualTo("Hello world"));
        }
    }
}
