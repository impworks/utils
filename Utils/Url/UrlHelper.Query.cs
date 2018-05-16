﻿using System;
using System.Collections.Generic;
using System.Linq;
using Impworks.Utils.Format;
using Impworks.Utils.Linq;

namespace Impworks.Utils.Url
{
    public static partial class UrlHelper
    {
        #region Public methods

        /// <summary>
        /// Converts the object's properties to a query string.
        /// </summary>
        /// <param name="obj">Object to deconstruct.</param>
        public static string GetQuery(object obj)
        {
            return GetQuery(GetObjectProperties(obj));
        }

        /// <summary>
        /// Renders the list of properties to a string.
        /// </summary>
        /// <param name="props">List of properties and their values.</param>
        public static string GetQuery(IEnumerable<KeyValuePair<string, object>> props)
        {
            return props.Select(x => RenderProperty(x.Key, x.Value))
                        .Where(x => x != null)
                        .JoinString("&");
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Returns the list of properties in an object.
        /// </summary>
        /// <param name="obj">Object to deconstruct.</param>
        private static IEnumerable<KeyValuePair<string, object>> GetObjectProperties(object obj)
        {
            if (obj == null)
                yield break;

            foreach (var prop in obj.GetType().GetProperties())
            {
                var value = prop.GetValue(obj);
                if (value == null)
                    continue;

                if (prop.PropertyType.IsArray)
                {
                    foreach(var elem in (dynamic) value)
                        yield return new KeyValuePair<string, object>(prop.Name, elem);
                }
                else
                {
                    yield return new KeyValuePair<string, object>(prop.Name, value);
                }
            }
        }

        /// <summary>
        /// Renders a single property from the query.
        /// </summary>
        private static string RenderProperty(string propName, object value)
        {
            if (value == null)
                return null;

            var strValue = value is IConvertible cvt
                ? cvt.ToInvariantString()
                : value.ToString();

            return Uri.EscapeDataString(propName) + "=" + Uri.EscapeDataString(strValue);
        }

        #endregion
    }
}
