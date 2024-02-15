using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Impworks.Utils.Format;
using Impworks.Utils.Linq;

namespace Impworks.Utils.Url;

public static partial class UrlHelper
{
    #region Public methods

    /// <summary>
    /// Converts the object's properties to a query string.
    /// </summary>
    /// <param name="obj">Object to deconstruct.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetQuery(object obj)
    {
        if(obj == null)
            throw new ArgumentNullException();

        var props = GetObjectProperties(obj);
        return GetQuery(props);
    }

    /// <summary>
    /// Renders the list of properties to a string.
    /// </summary>
    /// <param name="props">List of properties and their values.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string GetQuery<T>(IDictionary<string, T> props)
    {
        return GetQuery(props as IEnumerable<KeyValuePair<string, T>>);
    }

    /// <summary>
    /// Renders the list of properties to a string.
    /// </summary>
    /// <param name="props">List of properties and their values.</param>
    public static string GetQuery<T>(IEnumerable<KeyValuePair<string, T>> props)
    {
        if(props == null)
            throw new ArgumentNullException(nameof(props));

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
            if (prop.GetIndexParameters().Length > 0)
                continue;

            var value = prop.GetValue(obj);
            if (value == null)
                continue;

            if (value is IEnumerable enumValue and not string)
            {
                foreach(var elem in enumValue)
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