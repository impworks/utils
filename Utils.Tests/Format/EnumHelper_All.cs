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
        public void GetEnumDescriptions_generic_returns_lookup_of_descriptions()
        {
            var result = EnumHelper.GetEnumDescriptions<SampleEnum>();

            var expected = new Dictionary<SampleEnum, string>
            {
                [SampleEnum.Hello] = "First value",
                [SampleEnum.World] = "Other value",
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetEnumDescriptions_generic_falls_back_to_enum_keys()
        {
            var result = EnumHelper.GetEnumDescriptions<SampleEnum2>();

            var expected = new Dictionary<SampleEnum2, string>
            {
                [SampleEnum2.Hello] = "Hello",
                [SampleEnum2.World] = "World",
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetEnumDescriptions_nongeneric_returns_lookup_of_descriptions()
        {
            var result = EnumHelper.GetEnumDescriptions(typeof(SampleEnum));

            var expected = new Dictionary<object, string>
            {
                [SampleEnum.Hello] = "First value",
                [SampleEnum.World] = "Other value",
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetEnumDescriptions_nongeneric_falls_back_to_enum_keys()
        {
            var result = EnumHelper.GetEnumDescriptions(typeof(SampleEnum2));

            var expected = new Dictionary<object, string>
            {
                [SampleEnum2.Hello] = "Hello",
                [SampleEnum2.World] = "World",
            };

            Assert.That(result, Is.EqualTo(expected));
        }

        [Test]
        public void GetEnumDescription_returns_the_value()
        {
            Assert.That(SampleEnum.Hello.GetEnumDescription(), Is.EqualTo("First value"));
        }

        [Test]
        public void GetEnumValues_returns_the_array()
        {
            Assert.That(EnumHelper.GetEnumValues<SampleEnum>(), Is.EqualTo(new[] {SampleEnum.Hello, SampleEnum.World}));
        }

        [Test]
        [TestCase("hello")]
        [TestCase("HELLO")]
        [TestCase("wORlD")]
        public void IsDefined_can_ignore_case(string value)
        {
            Assert.IsTrue(EnumHelper.IsDefined<SampleEnum>(value, true));
        }
    }
}
