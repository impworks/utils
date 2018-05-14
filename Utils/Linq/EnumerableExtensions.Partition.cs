using System;
using System.Collections.Generic;
using System.Linq;

namespace Impworks.Utils.Linq
{
    /// <summary>
    /// Helper methods for IEnumerable.
    /// </summary>
    public static partial class EnumerableExtensions
    {
        /// <summary>
        /// Splits a flat sequence into a sequence of chunks of desired size.
        /// </summary>
        /// <example>
        /// new [] { 1, 2, 3, 4, 5, 6 }.PartitionBySize(2) => [1, 2], [3, 4], [5, 6]
        /// new [] { 1, 2, 3, 4, 5, 6 }.PartitionBySize(4) => [1, 2, 3, 4], [5, 6]
        /// new [] { 1 }.PartitionBySize(3) => [1]
        /// </example>
        /// <param name="source">Original sequence of values.</param>
        /// <param name="chunkSize">Maximum number of elements per chunk.</param>
        public static IEnumerable<List<T>> PartitionBySize<T>(this IEnumerable<T> source, int chunkSize)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(chunkSize < 1)
                throw new ArgumentException("Size of the chunk must be at least 1!");

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
        /// Splits the sequence into given number of roughly-equal sub-sequences
        /// </summary>
        /// <example>
        /// new [] { 1, 2, 3, 4, 5, 6 }.PartitionByCount(2) => [1, 2, 3], [4, 5, 6]
        /// new [] { 1, 2, 3, 4, 5, 6 }.PartitionByCount(3) => [1, 2], [3, 4], [5, 6]
        /// new [] { 1, 2, 3, 4, 5 }.PartitionByCount(2) => [1, 2, 3], [4, 5]
        /// new [] { 1 }.PartitionByCount(2) => [1]
        /// </example>
        /// <param name="source">Original sequence of values.</param>
        /// <param name="partsCount">Desired number of partitions.</param>
        public static List<List<T>> PartitionByCount<T>(this IEnumerable<T> source, int partsCount)
        {
            if(source == null)
                throw new ArgumentNullException(nameof(source));

            if(partsCount < 1)
                throw new ArgumentException("Size of the chunk must be at least 1!");

            var sourceList = source.ToList();
            var sublistLength = (int) Math.Ceiling((double)sourceList.Count/partsCount);

            var result = new List<List<T>>();
            var partition = new List<T>(sublistLength);

            foreach (var item in sourceList)
            {
                partition.Add(item);
                if (partition.Count == sublistLength)
                {
                    result.Add(partition);
                    partition = new List<T>(sublistLength);
                }
            }

            if(partition.Count > 0)
                result.Add(partition);

            return result;
        }
    }
}
