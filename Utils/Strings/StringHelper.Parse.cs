using System;
using System.Collections.Generic;
using System.Globalization;

namespace Impworks.Utils.Strings
{
    public static partial class StringHelper
    {
        /// <summary>
        /// Gets the parse function for a specific type.
        /// </summary>
        public static Func<string, T> GetParseFunction<T>()
        {
            var type = typeof(T);
            if (ParseFuncs.TryGetValue(type, out var func))
                return (Func<string, T>) func;

            throw new Exception($"No parser function found for type '{type.Name}'.");
        }

        /// <summary>
        /// Predefined parser functions.
        /// </summary>
        private static Dictionary<Type, Delegate> ParseFuncs = new Dictionary<Type, Delegate>
        {
            [typeof(int)] = (Func<string, int>) (x => int.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(uint)] = (Func<string, uint>) (x => uint.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(long)] = (Func<string, long>) (x => long.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(ulong)] = (Func<string, ulong>) (x => ulong.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(float)] = (Func<string, float>) (x => float.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
            [typeof(double)] = (Func<string, double>) (x => double.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
            [typeof(byte)] = (Func<string, byte>) (x => byte.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(sbyte)] = (Func<string, sbyte>) (x => sbyte.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(char)] = (Func<string, char>) (x => char.Parse(x)),
            [typeof(DateTime)] = (Func<string, DateTime>) (x => DateTime.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(DateTimeOffset)] = (Func<string, DateTimeOffset>) (x => DateTime.Parse(x, CultureInfo.InvariantCulture)),

            [typeof(int?)] = (Func<string, int?>) (x => int.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(uint?)] = (Func<string, uint?>) (x => uint.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(long?)] = (Func<string, long?>) (x => long.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(ulong?)] = (Func<string, ulong?>) (x => ulong.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(float?)] = (Func<string, float?>) (x => float.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
            [typeof(double?)] = (Func<string, double?>) (x => double.Parse(x.Replace(',', '.'), CultureInfo.InvariantCulture)),
            [typeof(byte?)] = (Func<string, byte?>) (x => byte.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(sbyte?)] = (Func<string, sbyte?>) (x => sbyte.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(char?)] = (Func<string, char?>) (x => char.Parse(x)),
            [typeof(DateTime?)] = (Func<string, DateTime?>) (x => DateTime.Parse(x, CultureInfo.InvariantCulture)),
            [typeof(DateTimeOffset?)] = (Func<string, DateTimeOffset?>) (x => DateTime.Parse(x, CultureInfo.InvariantCulture)),

            [typeof(string)] = (Func<string, string>) (x => x)
        };
    }
}
