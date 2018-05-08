using System;

namespace Impworks.Utils.Strings
{
    public static partial class StringHelper
    {
        /// <summary>
        /// Attempts to parse a string using the parse function.
        /// Returns null if an exception has been raised.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <param name="parseFunc">Parser function that creates a value from the string.</param>
        public static T? TryParse<T>(this string str, Func<string, T> parseFunc)
            where T: struct
        {
            try
            {
                return parseFunc(str);
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Attempts to parse a string using the parse function.
        /// Returns the default value for type   if an exception has been raised.
        /// </summary>
        /// <param name="str">Source string.</param>
        /// <param name="parseFunc">Parser function that creates a value from the string.</param>
        public static T TryParseDefault<T>(this string str, Func<string, T> parseFunc)
        {
            try
            {
                return parseFunc(str);
            }
            catch
            {
                return default;
            }
        }
    }
}
