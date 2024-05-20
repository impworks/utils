using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Linq;

namespace Impworks.Utils.Strings;

public static partial class StringHelper
{
    /// <summary>
    /// Gets the parse function for a specific type.
    /// </summary>
    public static Func<string, T> GetParseFunction<T>()
    {
        var type = typeof(T);
        if (ParseFuncs.TryGetValue(type, out var func))
            return (Func<string, T>)func;

        if (type.IsEnum)
            return x => (T)Enum.Parse(type, x, true);

        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            var innerType = type.GetGenericArguments()[0];
            if (innerType.IsEnum)
                return x => (T)Enum.Parse(innerType, x, true);
        }

        throw new Exception($"No parser function found for type '{type.Name}'.");
    }

    /// <summary>
    /// Predefined parser functions.
    /// </summary>
    private static Dictionary<Type, Delegate> ParseFuncs = new Dictionary<Type, Delegate>
    {
        [typeof(bool)] = (Func<string, bool>)(bool.Parse),
        [typeof(int)] = (Func<string, int>)(x => int.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(uint)] = (Func<string, uint>)(x => uint.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(long)] = (Func<string, long>)(x => long.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(ulong)] = (Func<string, ulong>)(x => ulong.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(float)] = (Func<string, float>)(x => float.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
        [typeof(double)] = (Func<string, double>)(x => double.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
        [typeof(byte)] = (Func<string, byte>)(x => byte.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(sbyte)] = (Func<string, sbyte>)(x => sbyte.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(char)] = (Func<string, char>)(char.Parse),
        [typeof(decimal)] = (Func<string, decimal>)(x => decimal.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(DateTime)] = (Func<string, DateTime>)(x => DateTime.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(DateTimeOffset)] = (Func<string, DateTimeOffset>)(x => DateTime.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(TimeSpan)] = (Func<string, TimeSpan>)(x => TimeSpan.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(Guid)] = (Func<string, Guid>)(Guid.Parse),

        [typeof(bool?)] = (Func<string, bool?>)(x => bool.Parse(x)),
        [typeof(int?)] = (Func<string, int?>)(x => int.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(uint?)] = (Func<string, uint?>)(x => uint.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(long?)] = (Func<string, long?>)(x => long.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(ulong?)] = (Func<string, ulong?>)(x => ulong.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(float?)] = (Func<string, float?>)(x => float.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
        [typeof(double?)] = (Func<string, double?>)(x => double.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
        [typeof(byte?)] = (Func<string, byte?>)(x => byte.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(sbyte?)] = (Func<string, sbyte?>)(x => sbyte.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(char?)] = (Func<string, char?>)(x => char.Parse(x)),
        [typeof(decimal?)] = (Func<string, decimal?>)(x => decimal.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(DateTime?)] = (Func<string, DateTime?>)(x => DateTime.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(DateTimeOffset?)] = (Func<string, DateTimeOffset?>)(x => DateTime.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(TimeSpan?)] = (Func<string, TimeSpan?>)(x => TimeSpan.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(Guid?)] = (Func<string, Guid?>)(x => Guid.Parse(x)),

        [typeof(string)] = (Func<string, string>)(x => x),
        [typeof(XElement)] = (Func<string, XElement>)(XElement.Parse),
        [typeof(XDocument)] = (Func<string, XDocument>)(XDocument.Parse),
        [typeof(Uri)] = (Func<string, Uri>)(x => new Uri(x, UriKind.RelativeOrAbsolute)),

#if NET6_0_OR_GREATER
        [typeof(DateOnly)] = (Func<string, DateOnly>)(x => DateOnly.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(DateOnly?)] = (Func<string, DateOnly?>)(x => DateOnly.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(TimeOnly)] = (Func<string, TimeOnly>)(x => TimeOnly.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(TimeOnly?)] = (Func<string, TimeOnly?>)(x => TimeOnly.Parse(x, CultureInfo.InvariantCulture)),

        [typeof(Half)] = (Func<string, Half>)(x => Half.Parse(x, CultureInfo.InvariantCulture)),
        [typeof(Half?)] = (Func<string, Half?>)(x => Half.Parse(x, CultureInfo.InvariantCulture)),
#endif
    };
}