using System;
using System.Globalization;

namespace Impworks.Utils.Strings
{
    public static partial class StringExtensions
    {
        /// <summary>
        /// Converts the first character of the string to uppercase.
        /// </summary>
        public static string Capitalize(this string str, CultureInfo culture)
        {
            if (str == null)
                throw new ArgumentNullException(nameof(str));

            if (culture == null)
                throw new ArgumentNullException(nameof(culture));

            if (str.Length == 0)
                return str;

            return str.Substring(0, 1).ToUpper(culture) + str.Substring(1);
        }

        /// <summary>
        /// Converts the first character of the string to uppercase.
        /// </summary>
        public static string Capitalize(this string str)
        {
            return Capitalize(str, CultureInfo.CurrentCulture);
        }
    }
}
