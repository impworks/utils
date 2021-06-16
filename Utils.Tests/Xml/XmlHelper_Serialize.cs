using System.Xml.Linq;
using Impworks.Utils.Xml;
using NUnit.Framework;
using Utils.Tests.Linq;

namespace Utils.Tests.Xml
{
    /// <summary>
    /// Tests for XmlHelper.Serialize.
    /// </summary>
    [TestFixture]
    public class XmlHelper_Serialize
    {
        SampleObject GetObj(bool useNull = false)
        {
            return new SampleObject(1, useNull ? null : "hello");
        }

        [Test]
        public void Serialize_produces_valid_xml()
        {
            var xml = XmlHelper.Serialize(GetObj());
            Assert.DoesNotThrow(() => XElement.Parse(xml));
        }

        #region Clean mode

        [Test]
        public void Serialize_removes_xml_header_in_clean_mode()
        {
            var xml = XmlHelper.Serialize(GetObj());
            Assert.IsTrue(xml.StartsWith("<SampleObject"));
        }

        [Test]
        public void Serialize_leaves_xml_header_in_unclean_mode()
        {
            var xml = XmlHelper.Serialize(GetObj(), clean: false);
            Assert.IsTrue(xml.StartsWith("<?xml version"));
        }

        [Test]
        public void Serialize_removes_namespaces_in_clean_mode()
        {
            var xml = XmlHelper.Serialize(GetObj());
            Assert.IsFalse(xml.Contains("http://www.w3.org/2001/XMLSchema-instance"));
            Assert.IsFalse(xml.Contains("http://www.w3.org/2001/XMLSchema"));
        }

        [Test]
        public void Serialize_leaves_namespaces_in_unclean_mode()
        {
            var xml = XmlHelper.Serialize(GetObj(), clean: false);
            Assert.IsTrue(xml.Contains("http://www.w3.org/2001/XMLSchema-instance"));
            Assert.IsTrue(xml.Contains("http://www.w3.org/2001/XMLSchema"));
        }

        [Test]
        public void Serialize_removes_nils_in_clean_mode()
        {
            var xml = XmlHelper.Serialize(GetObj(useNull: true));
            Assert.IsFalse(xml.Contains(@"xsi:nil=""true"""));
        }

        [Test]
        public void Serialize_leaves_nils_in_unclean_mode()
        {
            var xml = XmlHelper.Serialize(GetObj(useNull: true), clean: false);
            Assert.IsTrue(xml.Contains(@"xsi:nil=""true"""));
        }

        #endregion

        #region Indentation

        [Test]
        public void Serialize_uses_indentation_by_default()
        {
            var xml = XmlHelper.Serialize(GetObj());
            var lines = xml.Split('\n');
            Assert.Greater(lines.Length, 1);
            Assert.IsTrue(lines[1].StartsWith(" "));
        }

        [Test]
        public void Serialize_disables_indentation_via_flag()
        {
            var xml = XmlHelper.Serialize(GetObj(), indent: false);
            var lines = xml.Split('\n');
            Assert.AreEqual(lines.Length, 1);
        }

        #endregion

        #region Root element

        [Test]
        public void Serialize_uses_class_name_as_element_root_by_default()
        {
            var xml = XmlHelper.Serialize(GetObj());
            var elem = XElement.Parse(xml);
            Assert.AreEqual(elem.Name.LocalName, nameof(SampleObject));
        }

        [Test]
        public void Serialize_uses_specified_name_as_element_root()
        {
            var name = "FooBar";
            var xml = XmlHelper.Serialize(GetObj(), rootName: name);
            var elem = XElement.Parse(xml);
            Assert.AreEqual(elem.Name.LocalName, name);
        }

        #endregion

        #region Untyped serialization

        [Test]
        public void Serialize_uses_exact_object_type()
        {
            var xml = XmlHelper.Serialize((object) GetObj());
            Assert.IsTrue(xml.StartsWith("<SampleObject"));
        }

        #endregion
    }
}
