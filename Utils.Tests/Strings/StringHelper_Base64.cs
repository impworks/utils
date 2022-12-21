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

            Assert.AreEqual("SGVsbG8gd29ybGQ=", encoded);
        }

        [Test]
        public void Decode()
        {
            var src = "SGVsbG8gd29ybGQ=";
            var encoded = StringHelper.Base64Decode(src);

            Assert.AreEqual("Hello world", encoded);
        }
    }
}
