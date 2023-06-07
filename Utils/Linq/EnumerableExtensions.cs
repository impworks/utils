using System;
using System.Collections.Generic;
using System.Linq;

namespace Impworks.Utils.Linq
{
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Chainable method for joining a list of elements with a separator.
        /// </summary>
        /// <param name="source">List of elements.</param>
        /// <param name="separator">Separator to place between elements.</param>
        public static string JoinString<T>(this IEnumerable<T> source, string separator)
        {
            return string.Join(separator, source);
        }

#if !NET6_0_OR_GREATER
        /// <summary>
        /// Excludes duplicate values from the list (specified by an expression).
        /// </summary>
        /// <param name="sequence">Original sequence.</param>
        /// <param name="idGetter">Element projection that returns must-be-unique values.</param>
        public static IEnumerable<T> DistinctBy<T, TValue>(this IEnumerable<T> sequence, Func<T, TValue> idGetter)
        {
            var hashSet = new HashSet<TValue>();
            return sequence.Where(x => hashSet.Add(idGetter(x)));
        }
#endif

        /// <summary>
        /// Adds a list of items into the collection.
        /// </summary>
        /// <param name="collection">Target collection.</param>
        /// <param name="data">Elements to add to the collection.</param>
        public static void AddRange<T>(this ICollection<T> collection, IEnumerable<T> data)
        {
            foreach (var item in data)
                collection.Add(item);
        }
    }
}
