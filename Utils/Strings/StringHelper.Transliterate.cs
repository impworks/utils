using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Impworks.Utils.Strings
{
    public static partial class StringHelper
    {
        /// <summary>
        /// Russian to english character mapping.
        /// </summary>
        private static readonly Dictionary<char, string> _charMap = new Dictionary<char, string>
        {
            ['а'] = "a",
            ['б'] = "b",
            ['в'] = "v",
            ['г'] = "g",
            ['д'] = "d",
            ['е'] = "e",
            ['ё'] = "yo",
            ['ж'] = "zh",
            ['з'] = "z",
            ['и'] = "i",
            ['й'] = "j",
            ['к'] = "k",
            ['л'] = "l",
            ['м'] = "m",
            ['н'] = "n",
            ['о'] = "o",
            ['п'] = "p",
            ['р'] = "r",
            ['с'] = "s",
            ['т'] = "t",
            ['у'] = "u",
            ['ф'] = "f",
            ['х'] = "kh",
            ['ц'] = "ts",
            ['ч'] = "ch",
            ['ш'] = "sh",
            ['щ'] = "sch",
            ['ъ'] = "'",
            ['ы'] = "y",
            ['ь'] = "'",
            ['э'] = "e",
            ['ю'] = "yu",
            ['я'] = "ya"
        };

        /// <summary>
        /// Characters that must not be transliterated.
        /// </summary>
        private static readonly Regex _safeChecker = new Regex(@"[a-z0-9_\.-]", RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.ExplicitCapture);

        /// <summary>
        /// Transliterates a string, replacing russian characters with english ones.
        /// </summary>
        /// <param name="str">String to transliterate.</param>
        /// <param name="fallbackChar">Character to use instead of unknown locale chars. Defaults to dash.</param>
        /// <param name="safeRegex">Regular expression to check characters that must be left as-is.</param>
        /// <param name="cleanOutput">Flag indicating that fallback characters will be cleaned on start/end and not duplicated.</param>
        public static string Transliterate(string str, string fallbackChar = "-", string safeRegex = null, bool cleanOutput = true)
        {
            var sb = new StringBuilder(str.Length);
            var safeChecker = safeRegex == null ? _safeChecker : new Regex(safeRegex, RegexOptions.IgnoreCase | RegexOptions.ExplicitCapture);
            var lastAddedFallback = false;

            foreach (var ch in str)
            {
                // character is russian
                if (_charMap.TryGetValue(ch, out var rep))
                {
                    sb.Append(rep);
                    lastAddedFallback = false;
                    continue;
                }

                var chstr = ch.ToString();

                // character is russian, but uppercase: capitalize it
                if (_charMap.TryGetValue(chstr.ToLowerInvariant()[0], out var repUpper))
                {
                    sb.Append(repUpper.Capitalize());
                    lastAddedFallback = false;
                    continue;
                }

                // character is safe: append as is
                if (safeChecker.IsMatch(chstr))
                {
                    sb.Append(ch);
                    lastAddedFallback = false;
                    continue;
                }

                // fallback
                if (!lastAddedFallback || !cleanOutput)
                {
                    sb.Append(fallbackChar);
                    lastAddedFallback = true;
                }
            }

            var result = sb.ToString();

            if (cleanOutput)
            {
                var esc = Regex.Escape(fallbackChar);
                result = Regex.Replace(result, $"^{esc}|{esc}$", "");
            }

            return result;
        }
    }
}
