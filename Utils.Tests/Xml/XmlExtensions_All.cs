using System;
using System.Xml.Linq;
using Impworks.Utils.Xml;
using NUnit.Framework;

namespace Utils.Tests.Xml
{
    /// <summary>
    /// Tests for XmlExtensions methods.
    /// </summary>
    [TestFixture]
    public class XmlExtensions_All
    {
        public XElement GetXml()
        {
            return new XElement(
                "A",
                new XAttribute("B", 123),
                new XAttribute("C", "@123")
            );
        }

        [Test]
        public void Attr_returns_attribute_value()
        {
            Assert.AreEqual("123", GetXml().Attr("B"));
        }

        [Test]
        public void Attr_returns_null_for_missing_attribute()
        {
            Assert.IsNull(GetXml().Attr("X"));
        }

        [Test]
        public void Attr_throws_on_null_xml()
        {
            Assert.Throws<ArgumentNullException>(() => (null as XElement).Attr("A"));
        }

        [Test]
        public void Attr_throws_on_null_attribute_name()
        {
            Assert.Throws<ArgumentNullException>(() => GetXml().Attr(null));
        }

        [Test]
        public void ParseAttr_returns_parsed_attribute_value()
        {
            Assert.AreEqual(123, GetXml().ParseAttr<int>("B"));
        }
        
        [Test]
        public void ParseAttr_uses_parseFunc()
        {
            Assert.AreEqual(123, GetXml().ParseAttr("B", x => int.Parse(x.TrimStart('@'))));
        }

        [Test]
        public void ParseAttr_throws_on_missing_attribute()
        {
            Assert.Throws<ArgumentException>(() => GetXml().ParseAttr<int>("X"));
        }

        [Test]
        public void ParseAttr_throws_on_null_xml()
        {
            Assert.Throws<ArgumentNullException>(() => (null as XElement).ParseAttr<int>("A"));
        }

        [Test]
        public void ParseAttr_throws_on_null_attribute_name()
        {
            Assert.Throws<ArgumentNullException>(() => GetXml().ParseAttr<int>(null));
        }

        [Test]
        public void TryParseAttr_returns_parsed_attribute_value()
        {
            Assert.AreEqual(123, GetXml().TryParseAttr<int>("B"));
        }

        [Test]
        public void TryParseAttr_returns_null_on_missing_attribute()
        {
            Assert.IsNull(GetXml().TryParseAttr<int?>("X"));
        }

        [Test]
        public void TryParseAttr_uses_parseFunc()
        {
            Assert.AreEqual(123, GetXml().TryParseAttr("B", x => int.Parse(x.TrimStart('@'))));
        }

        [Test]
        public void TryParseAttr_throws_on_null_xml()
        {
            Assert.Throws<ArgumentNullException>(() => (null as XElement).TryParseAttr<int>("A"));
        }

        [Test]
        public void TryParseAttr_throws_on_null_attribute_name()
        {
            Assert.Throws<ArgumentNullException>(() => GetXml().TryParseAttr<int>(null));
        }
    }
}