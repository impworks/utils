using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Linq;

#if NETSTANDARD || NET6_0_OR_GREATER
public static partial class EnumerableExtensions
{
    #region FirstN

    /// <summary>
    /// Returns the tuple containing first 2 items of the sequence.
    /// Throws an exception if there are not enough elements.
    /// </summary>
    public static ValueTuple<T, T> First2<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>()
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 3 items of the sequence.
    /// Throws an exception if there are not enough elements.
    /// </summary>
    public static ValueTuple<T, T, T> First3<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>()
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 4 items of the sequence.
    /// Throws an exception if there are not enough elements.
    /// </summary>
    public static ValueTuple<T, T, T, T> First4<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>()
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 5 items of the sequence.
    /// Throws an exception if there are not enough elements.
    /// </summary>
    public static ValueTuple<T, T, T, T, T> First5<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>()
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 6 items of the sequence.
    /// Throws an exception if there are not enough elements.
    /// </summary>
    public static ValueTuple<T, T, T, T, T, T> First6<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>()
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 7 items of the sequence.
    /// Throws an exception if there are not enough elements.
    /// </summary>
    public static ValueTuple<T, T, T, T, T, T, T> First7<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>(),
            iter.MoveNext() ? iter.Current : ThrowTooFew<T>()
        );
    }

    #endregion
    
    #region FirstNOrDefault

    /// <summary>
    /// Returns the tuple containing first 2 items of the sequence.
    /// </summary>
    public static ValueTuple<T, T> First2OrDefault<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 3 items of the sequence.
    /// </summary>
    public static ValueTuple<T, T, T> First3OrDefault<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 4 items of the sequence.
    /// </summary>
    public static ValueTuple<T, T, T, T> First4OrDefault<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 5 items of the sequence.
    /// </summary>
    public static ValueTuple<T, T, T, T, T> First5OrDefault<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 6 items of the sequence.
    /// </summary>
    public static ValueTuple<T, T, T, T, T, T> First6OrDefault<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default
        );
    }
    
    /// <summary>
    /// Returns the tuple containing first 7 items of the sequence.
    /// </summary>
    public static ValueTuple<T, T, T, T, T, T, T> First7OrDefault<T>(this IEnumerable<T> src)
    {
        using var iter = src.GetEnumerator();
        return (
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default,
            iter.MoveNext() ? iter.Current : default
        );
    }

    #endregion

    #region Helpers

    /// <summary>
    /// Throws an exception if there are too few elements in the sequence.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    private static T ThrowTooFew<T>()
    {
        throw new Exception("Sequence contains too few elements");
    }

    #endregion
}
#endif