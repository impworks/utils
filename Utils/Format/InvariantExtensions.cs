using System;
using System.Globalization;

namespace Impworks.Utils.Format
{
    /// <summary>
    /// Invariant formatting methods.
    /// </summary>
    public static class InvariantExtensions
    {
        /// <summary>
        /// Formats the value using Invariant Culture.
        /// </summary>
        public static string ToInvariantString(this IConvertible value)
        {
            return value.ToString(CultureInfo.InvariantCulture);
        }
    }
}
