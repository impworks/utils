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
            return str.Substring(0, 1).ToUpper(culture) + str.Substring(1);
        }

        /// <summary>
        /// Converts the first character of the string to uppercase.
        /// </summary>
        public static string Capitalize(this string str)
        {
            return str.Substring(0, 1).ToUpper(CultureInfo.InvariantCulture) + str.Substring(1);
        }
    }
}
