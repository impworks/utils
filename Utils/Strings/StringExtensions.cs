using System;

namespace Impworks.Utils.Strings
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Returns null if the string is null or empty.
        /// </summary>
        /// <param name="str">Checked string.</param>
        /// <param name="allowWhitespace">Flag indicating that strings with whitespace chars are considered non-empty.</param>
        /// <returns>Null if the string is empty/whitespaced, otherwise the string itself.</returns>
        public static string ValueOrNull(this string str, bool allowWhitespace = false)
        {
            var check = allowWhitespace
                ? (Func<string, bool>) string.IsNullOrEmpty
                : string.IsNullOrWhiteSpace;

            return check(str) ? null : str;
        }
    }
}
