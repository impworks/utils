using System;
using System.Collections.Generic;

namespace Impworks.Utils.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Applies an action to all items in the tree.
    /// </summary>
    /// <param name="objects">Root list of items.</param>
    /// <param name="childSelector">Function that selects children of a node.</param>
    /// <param name="action">Action to perform on all children.</param>
    public static void ApplyRecursively<T>(this IEnumerable<T> objects, Func<T, IEnumerable<T>> childSelector, Action<T> action)
    {
        if (objects == null)
            return;

        foreach (var obj in objects)
        {
            action(obj);
            childSelector(obj).ApplyRecursively(childSelector, action);
        }
    }

    /// <summary>
    /// Selects all tree items into a single flat list.
    /// </summary>
    /// <param name="objects">Root list of items.</param>
    /// <param name="childSelector">Function that selects children of a single node.</param>
    public static IEnumerable<T> SelectRecursively<T>(this IEnumerable<T> objects, Func<T, IEnumerable<T>> childSelector)
    {
        if (objects == null)
            yield break;

        foreach (var obj in objects)
        {
            yield return obj;

            var children = childSelector(obj);
            foreach (var child in children.SelectRecursively(childSelector))
                yield return child;
        }
    }
}