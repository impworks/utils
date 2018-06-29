using System.Collections.Generic;

namespace Impworks.Utils.Dictionary
{
    /// <summary>
    /// Helper methods for dictionaries.
    /// </summary>
    public static class DictionaryExtensions
    {
        /// <summary>
        /// Returns the value if it exists in the dictionary.
        /// Otherwise, the default value for the type is returned.
        /// </summary>
        public static TVal TryGetValue<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key)
        {
            return dict.TryGetValue(key, out var result) ? result : default;
        }

        /// <summary>
        /// Returns the value if it exists in the dictionary.
        /// Otherwise, null is returned.
        /// </summary>
        public static TVal? TryGetNullableValue<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key)
            where TVal: struct
        {
            return dict.TryGetValue(key, out var result) ? result : (TVal?) null;
        }
    }
}
