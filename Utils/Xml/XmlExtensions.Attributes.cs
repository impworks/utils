using System;
using System.Xml.Linq;
using Impworks.Utils.Strings;

namespace Impworks.Utils.Xml
{
    /// <summary>
    /// Helper methods for XML.
    /// </summary>
    public static class XmlExtensions
    {
        /// <summary>
        /// Returns the string value of an attribute.
        /// </summary>
        /// <param name="xml">XElement with the attribute.</param>
        /// <param name="name">Name of the attribute.</param>
        /// <returns>String value of the attribute, or null.</returns>
        public static string Attr(this XElement xml, string name)
        {
            if(xml == null)
                throw new ArgumentNullException(nameof(xml));

            if(name == null)
                throw new ArgumentNullException(nameof(name));

            return xml.Attribute(name)?.Value;
        }

        /// <summary>
        /// Attempts to parse an attribute's value safely.
        /// </summary>
        /// <param name="xml">XElement with the attribute.</param>
        /// <param name="name">Name of the attribute.</param>
        /// <param name="parseFunc">Parser function. If not specified, the default function will be used for built-in types.</param>
        /// <returns>Converted value of the attribute, or default.</returns>
        public static T TryParseAttr<T>(this XElement xml, string name, Func<string, T> parseFunc = null)
        {
            return xml.Attr(name).TryParse(parseFunc);
        }

        /// <summary>
        /// Attempts to parse an attribute's value safely.
        /// </summary>
        /// <param name="xml">XElement with the attribute.</param>
        /// <param name="name">Name of the attribute.</param>
        /// <param name="parseFunc">Parser function. If not specified, the default function will be used for built-in types.</param>
        /// <returns>Converted value of the attribute, or default.</returns>
        public static T ParseAttr<T>(this XElement xml, string name, Func<string, T> parseFunc = null)
        {
            var value = xml.Attr(name);
            if(value == null)
                throw new ArgumentException($"Attribute '{name}' does not exist.", nameof(name));

            return value.Parse(parseFunc);
        }
    }
}
