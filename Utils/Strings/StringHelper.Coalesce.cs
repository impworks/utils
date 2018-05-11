using System;
using System.Collections.Generic;
using System.Linq;

namespace Impworks.Utils.Strings
{
    /// <summary>
    /// The collection of various string-related methods.
    /// </summary>
    public static partial class StringHelper
    {
        /// <summary>
        /// Returns the first non-empty string from the specified list.
        /// </summary>
        public static string Coalesce(IEnumerable<string> args)
        {
            return args.FirstOrDefault(x => !string.IsNullOrEmpty(x));
        }

        /// <summary>
        /// Returns the first non-empty string from the specified list.
        /// </summary>
        public static string Coalesce(params string[] args)
        {
            return Coalesce(args as IEnumerable<string>);
        }

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
