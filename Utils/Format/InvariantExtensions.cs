using System;
using System.Globalization;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Format;

/// <summary>
/// Invariant formatting methods.
/// </summary>
public static class InvariantExtensions
{
    /// <summary>
    /// Formats the value using Invariant Culture.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string ToInvariantString(this IConvertible value)
    {
        return value.ToString(CultureInfo.InvariantCulture);
    }
}