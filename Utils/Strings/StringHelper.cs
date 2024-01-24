using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Strings;

/// <summary>
/// The collection of various string-related methods.
/// </summary>
public static partial class StringHelper
{
    /// <summary>
    /// Returns the first non-empty string from the specified list.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Coalesce(IEnumerable<string> args)
    {
        return args.FirstOrDefault(x => !string.IsNullOrEmpty(x));
    }

    /// <summary>
    /// Returns the first non-empty string from the specified list.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static string Coalesce(params string[] args)
    {
        return Coalesce(args as IEnumerable<string>);
    }
}