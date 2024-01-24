using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Dictionary;

/// <summary>
/// Helper methods for dictionaries.
/// </summary>
public static class DictionaryExtensions
{
    /// <summary>
    /// Returns the value if it exists in the dictionary.
    /// Otherwise, the default value for the type is returned.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TVal TryGetValue<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key)
    {
        return key != null && dict.TryGetValue(key, out var result) ? result : default;
    }

    /// <summary>
    /// Returns the value for the first key in the list that exists in the dictionary.
    /// Otherwise, the default value for the type is returned.
    /// </summary>
    public static TVal TryGetValue<TKey, TVal>(this IDictionary<TKey, TVal> dict, params TKey[] keys)
    {
        if(keys != null)
            foreach (var key in keys)
                if (key != null && dict.TryGetValue(key, out var result))
                    return result;

        return default;
    }

    /// <summary>
    /// Returns the value if it exists in the dictionary.
    /// If no keys exist, null is returned.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static TVal? TryGetNullableValue<TKey, TVal>(this IDictionary<TKey, TVal> dict, TKey key)
        where TVal: struct
    {
        return key != null && dict.TryGetValue(key, out var result) ? result : null;
    }

    /// <summary>
    /// Returns the value for the first key in the list that exists in the dictionary.
    /// If no keys exist, null is returned.
    /// </summary>
    public static TVal? TryGetNullableValue<TKey, TVal>(this IDictionary<TKey, TVal> dict, params TKey[] keys)
        where TVal: struct
    {
        if(keys != null)
            foreach (var key in keys)
                if (key != null && dict.TryGetValue(key, out var result))
                    return result;

        return null;
    }
}