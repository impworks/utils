using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using Impworks.Utils.Random;

namespace Impworks.Utils.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Returns the sequence of the same items in random order.
    /// </summary>
    public static IEnumerable<T> Shuffle<T>(this IEnumerable<T> source)
    {
        return source.Select(x => new { Value = x, Random = RandomHelper.Float() })
                     .OrderBy(x => x.Random)
                     .Select(x => x.Value);
    }

    /// <summary>
    /// Picks a random element from the collection.
    /// </summary>
    /// <param name="source">Source collection.</param>
    /// <param name="weightFunc">
    /// Weight function. Elements with bigger weight are more likely to be selected.
    /// If not specified, all elements have equal weights.
    /// </param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T PickRandom<T>(this IReadOnlyList<T> source, Func<T, double> weightFunc = null)
    {
        if (weightFunc != null)
            return RandomHelper.PickWeighted(source, weightFunc);

        return RandomHelper.Pick(source);
    }
}