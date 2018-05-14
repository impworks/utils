using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Impworks.Utils.Linq;

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

        /// <summary>
        /// Converts the list of arguments to a query.
        /// </summary>
        public static string ToQueryString(this IEnumerable<KeyValuePair<string, string>> args)
        {
            Func<string, string> escape = Uri.EscapeDataString;
            return args.Select(x => $"{escape(x.Key)}={escape(x.Value)}").JoinString("&");
        }
    }
}
