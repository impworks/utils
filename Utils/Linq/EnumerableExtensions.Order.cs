using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Impworks.Utils.Random;

namespace Impworks.Utils.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Orders the sequence by a field with direction based on a flag.
        /// </summary>
        public static IOrderedEnumerable<T> OrderBy<T, T2>(this IEnumerable<T> source, Func<T, T2> orderExpr, bool isDescending)
        {
            return isDescending
                ? source.OrderByDescending(orderExpr)
                : source.OrderBy(orderExpr);
        }

        /// <summary>
        /// Orders the sequence by a field with direction based on a flag.
        /// </summary>
        public static IOrderedEnumerable<T> ThenBy<T, T2>(this IOrderedEnumerable<T> source, Func<T, T2> orderExpr, bool isDescending)
        {
            return isDescending
                ? source.ThenByDescending(orderExpr)
                : source.ThenBy(orderExpr);
        }

        /// <summary>
        /// Orders the query by a field with direction based on a flag.
        /// </summary>
        public static IOrderedQueryable<T> OrderBy<T, T2>(this IQueryable<T> source, Expression<Func<T, T2>> orderExpr, bool isDescending)
        {
            return isDescending
                ? source.OrderByDescending(orderExpr)
                : source.OrderBy(orderExpr);
        }

        /// <summary>
        /// Orders the query by a field with direction based on a flag.
        /// </summary>
        public static IOrderedQueryable<T> ThenBy<T, T2>(this IOrderedQueryable<T> source, Expression<Func<T, T2>> orderExpr, bool isDescending)
        {
            return isDescending
                ? source.ThenByDescending(orderExpr)
                : source.ThenBy(orderExpr);
        }

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
        public static T PickRandom<T>(this IReadOnlyList<T> source, Func<T, double> weightFunc = null)
        {
            if (weightFunc != null)
                return RandomHelper.PickWeighted(source, weightFunc);

            return RandomHelper.Pick(source);
        }
    }
}
