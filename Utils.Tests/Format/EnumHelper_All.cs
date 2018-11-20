using System.Collections.Generic;
using Impworks.Utils.Format;
using NUnit.Framework;

namespace Utils.Tests.Format
{
    /// <summary>
    /// Tests for EnumHelper.
    /// </summary>
    [TestFixture]
    public class EnumHelper_All
    {
        [Test]
        public void GetEnumDescriptions_returns_lookup_of_descriptions()
        {
            var result = EnumHelper.GetEnumDescriptions<SampleEnum>();

            var expected = new Dictionary<SampleEnum, string>
            {
                [SampleEnum.Hello] = "First value",
                [SampleEnum.World] = "Other value",
            };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumDescriptions_falls_back_to_enum_keys()
        {
            var result = EnumHelper.GetEnumDescriptions<SampleEnum2>();

            var expected = new Dictionary<SampleEnum2, string>
            {
                [SampleEnum2.Hello] = "Hello",
                [SampleEnum2.World] = "World",
            };

            Assert.AreEqual(expected, result);
        }

        [Test]
        public void GetEnumDescription_returns_the_value()
        {
            Assert.AreEqual("First value", SampleEnum.Hello.GetEnumDescription());
        }

        [Test]
        public void GetEnumValues_returns_the_array()
        {
            Assert.AreEqual(new[] {SampleEnum.Hello, SampleEnum.World}, EnumHelper.GetEnumValues<SampleEnum>());
        }
    }
}
