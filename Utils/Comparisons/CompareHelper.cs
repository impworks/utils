using System;
using System.Collections.Generic;

namespace Impworks.Utils.Comparisons;

/// <summary>
/// Helper methods to work with comparable values.
/// </summary>
public class CompareHelper
{
    /// <summary>
    /// General comparator that returns the minimal value of the two.
    /// </summary>
    public static T Min<T>(T a, T b) where T : IComparable<T>
    {
        var cmp = Comparer<T>.Default;
        return cmp.Compare(a, b) < 0 ? a : b;
    }

    /// <summary>
    /// General comparator that returns the minimal value of the list.
    /// </summary>
    public static T Min<T>(params T[] elems) where T : IComparable<T>
    {
        if (elems.Length == 0)
            throw new ArgumentException("At least 1 element is expected");

        var cmp = Comparer<T>.Default;
        var min = elems[0];

        for (var i = 1; i < elems.Length; i++)
            if (cmp.Compare(elems[i], min) < 0)
                min = elems[i];

        return min;
    }

    /// <summary>
    /// General comparator that returns the maximal value of the two.
    /// </summary>
    public static T Max<T>(T a, T b) where T : IComparable<T>
    {
        var cmp = Comparer<T>.Default;
        return cmp.Compare(a, b) > 0 ? a : b;
    }

    /// <summary>
    /// General comparator that returns the maximal value of the list.
    /// </summary>
    public static T Max<T>(params T[] elems) where T : IComparable<T>
    {
        if (elems.Length == 0)
            throw new ArgumentException("At least 1 element is expected");

        var cmp = Comparer<T>.Default;
        var max = elems[0];

        for (var i = 1; i < elems.Length; i++)
            if (cmp.Compare(elems[i], max) > 0)
                max = elems[i];

        return max;
    }
}