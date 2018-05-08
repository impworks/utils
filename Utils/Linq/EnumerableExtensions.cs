using System.Collections.Generic;

namespace Impworks.Utils.Linq
{
    /// <summary>
    /// Helper methods for IEnumerable.
    /// </summary>
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Splits a flat sequence into a sequence of chunks of desired size.
        /// </summary>
        /// <param name="source">Original sequence of values.</param>
        /// <param name="chunkSize">Maximum number of elements per chunk.</param>
        public static IEnumerable<List<T>> SplitToChunks<T>(this IEnumerable<T> source, int chunkSize)
        {
            var batch = new List<T>(chunkSize);

            foreach (var item in source)
            {
                batch.Add(item);

                if (batch.Count == chunkSize)
                {
                    yield return batch;
                    batch = new List<T>(chunkSize);
                }
            }

            if (batch.Count > 0)
                yield return batch;
        }

        /// <summary>
        /// Chainable method for joining a list of elements with a separator.
        /// </summary>
        /// <param name="source">List of elements.</param>
        /// <param name="separator">Separator to place between elements.</param>
        public static string JoinString<T>(this IEnumerable<T> source, string separator)
        {
            return string.Join(separator, source);
        }
    }
}
