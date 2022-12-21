using System;
using System.Text;

namespace Impworks.Utils.Strings
{
    public static partial class StringHelper
    {
        /// <summary>
        /// Converts a string to base64 encoding.
        /// </summary>
        /// <param name="str">String to encode.</param>
        /// <param name="enc">Encoding to use. Defaults to UTF-8.</param>
        public static string Base64Encode(string str, Encoding enc = null)
        {
            var encoding = enc ?? Encoding.UTF8;
            return Convert.ToBase64String(encoding.GetBytes(str));
        }

        /// <summary>
        /// Converts a string from base64 encoding.
        /// </summary>
        /// <param name="str">String to decode.</param>
        /// <param name="enc">Encoding to use. Defaults to UTF-8.</param>
        public static string Base64Decode(string str, Encoding enc = null)
        {
            var encoding = enc ?? Encoding.UTF8;
            return encoding.GetString(Convert.FromBase64String(str));
        }
    }
}
