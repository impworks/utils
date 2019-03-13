using System;
using System.Linq;

namespace Impworks.Utils.Url
{
    /// <summary>
    /// Helper utilities for URLs.
    /// </summary>
    public static partial class UrlHelper
    {
        /// <summary>
        /// Safely combines the URI from authority and parts.
        /// </summary>
        public static Uri Combine(string authority, params string[] parts)
        {
            if(string.IsNullOrEmpty(authority))
                throw new ArgumentNullException(nameof(authority));

            if(parts == null)
                throw new ArgumentNullException(nameof(parts));

            if (!authority.EndsWith("/"))
                authority += "/";

            var safeParts = parts.Where(x => !string.IsNullOrWhiteSpace(x))
                                 .Select(x => x.Trim('/', '\\'));

            return new Uri(new Uri(authority), string.Join("/", safeParts));
        }
    }
}
