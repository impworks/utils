using System;
using System.Collections.Concurrent;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.Serialization;

namespace Impworks.Utils.Xml
{
    /// <summary>
    /// Helper methods for (de)serializing objects from XML.
    /// </summary>
    public static class XmlHelper
    {
        static XmlHelper()
        {
            SerializersCache = new ConcurrentDictionary<Tuple<Type, string>, XmlSerializer>();
            EmptyNamespaces = new XmlSerializerNamespaces(new[] {XmlQualifiedName.Empty});
            NilCleanRegex = new Regex(
                @"\s*(xmlns:[a-z0-9]+=""http://www\.w3\.org/2001/XMLSchema-instance""|[a-z0-9]+:nil=""true"")",
                RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.ExplicitCapture
            );
        }

        /// <summary>
        /// Global cache for Serializer instances.
        /// </summary>
        private static readonly ConcurrentDictionary<Tuple<Type, string>, XmlSerializer> SerializersCache;

        /// <summary>
        /// Empty namespaces setting.
        /// </summary>
        private static readonly XmlSerializerNamespaces EmptyNamespaces;

        /// <summary>
        /// Regular expression for removing "nil" notification for empty fields.
        /// </summary>
        private static readonly Regex NilCleanRegex;

        #region Serialize

        /// <summary>
        /// Converts the object to an XML representation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="serializer">Serializer.</param>
        /// <param name="clean">Flag indicating that the XML must be cleaned up. This removes the declaration, namespaces and "nil" values.</param>
        /// <param name="indent">Flag indicating that the XML must be indented.</param>
        /// <param name="enc">Encoding to use. Defaults to UTF-8.</param>
        /// <returns>Serialized object.</returns>
        public static string Serialize<T>(T obj, XmlSerializer serializer = null, bool clean = true, bool indent = true, Encoding enc = null)
        {
            if (obj == null)
                throw new ArgumentNullException(nameof(obj));

            if (serializer == null)
                serializer = GetSerializer(typeof(T));

            var options = new XmlWriterSettings
            {
                OmitXmlDeclaration = clean,
                Indent = indent,
                Encoding = enc ?? Encoding.UTF8
            };

            using (var sw = new StringWriter())
            using (var xw = XmlWriter.Create(sw, options))
            {
                serializer.Serialize(xw, obj, clean ? EmptyNamespaces : null);
                var result = sw.ToString();

                if (clean)
                    result = NilCleanRegex.Replace(result, "");

                return result;
            }
        }

        /// <summary>
        /// Converts the object to an XML representation.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="obj">Object to serialize.</param>
        /// <param name="rootName">Name of the root element.</param>
        /// <param name="clean">Flag indicating that the XML must be cleaned up. This removes the declaration, namespaces and "nil" values.</param>
        /// <param name="indent">Flag indicating that the XML must be indented.</param>
        /// <param name="enc">Encoding to use. Defaults to UTF-8.</param>
        /// <returns>Serialized object.</returns>
        public static string Serialize<T>(T obj, string rootName, bool clean = true, bool indent = true, Encoding enc = null)
        {
            var ser = GetSerializer(typeof(T), rootName);
            return Serialize(obj, ser, clean, indent, enc);
        }

        #endregion

        #region Deserialization

        /// <summary>
        /// Deserializes the object from XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">XML representation of the object.</param>
        /// <param name="serializer">Serializer.</param>
        /// <returns>Deserialized object.</returns>
        public static T Deserialize<T>(string xml, XmlSerializer serializer = null)
        {
            if(xml == null)
                throw new ArgumentNullException(nameof(xml));

            if(serializer == null)
                serializer = GetSerializer(typeof(T));

            using (var sr = new StringReader(xml))
                return (T) serializer.Deserialize(sr);
        }

        /// <summary>
        /// Deserializes the object from XML.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">XML representation of the object.</param>
        /// <param name="rootName">Name of the root element.</param>
        /// <returns>Deserialized object.</returns>
        public static T Deserialize<T>(string xml, string rootName)
        {
            var ser = GetSerializer(typeof(T), rootName);
            return Deserialize<T>(xml, ser);
        }

        #endregion

        #region Serializer caching

        /// <summary>
        /// Returns the appropriate serializer.
        /// </summary>
        private static XmlSerializer GetSerializer(Type type, string name = null)
        {
            var key = Tuple.Create(type, name);
            return SerializersCache.GetOrAdd(key, k => Create());

            XmlSerializer Create()
            {
                if(string.IsNullOrEmpty(name))
                    return new XmlSerializer(type);

                return new XmlSerializer(type, new XmlRootAttribute(name));
            }
        }

        #endregion
    }
}
