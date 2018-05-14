using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Impworks.Utils.Strings
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Parses the value to a type using default parsers.
        /// Throws an exception if the value cannot be parsed.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <param name="parseFunc">Parser function that creates a value from the string.</param>
        public static T Parse<T>(this string str, Func<string, T> parseFunc = null)
        {
            var func = parseFunc ?? GetParseFunction<T>();
            return func(str);
        }

        /// <summary>
        /// Attempts to parse a string using the parse function.
        /// Returns the default value if an exception has been raised.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <param name="parseFunc">Parser function that creates a value from the string. Default parser is used for built-in types.</param>
        public static T TryParse<T>(this string str, Func<string, T> parseFunc = null)
        {
            var func = parseFunc ?? GetParseFunction<T>();

            try
            {
                if (str != null)
                    return func(str);
            }
            catch
            {
                // do nothing
            }

            return default;
        }

        /// <summary>
        /// Converts a string with delimiter-separated value representations to a list of values.
        /// </summary>
        /// <param name="str">Splittable string.</param>
        /// <param name="separator">Sequence of characters that delimits values in the string. Defaults to a comma.</param>
        /// <param name="parseFunc">Parser function that creates a value from the string part. Default parser is used for built-in types.</param>
        public static IReadOnlyList<T> TryParseList<T>(this string str, string separator = ",", Func<string, T> parseFunc = null)
        {
            var result = new List<T>();

            if (str != null)
            {
                var parts = str.Split(new[] {separator}, StringSplitOptions.None);
                var func = parseFunc ?? GetParseFunction<T>();

                foreach (var part in parts)
                {
                    try
                    {
                        result.Add(func(part));
                    }
                    catch
                    {
                        // do nothing
                    }
                }
            }

            return result;
        }

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

        #region Parse functions

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

        #endregion
    }
}
