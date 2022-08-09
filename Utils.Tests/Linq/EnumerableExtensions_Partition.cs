using System;
using System.Linq;
using Impworks.Utils.Linq;
using NUnit.Framework;

namespace Utils.Tests.Linq
{
    /// <summary>
    /// Tests for EnumerableExtensions.PartitionByX methods.
    /// </summary>
    [TestFixture]
    public class EnumerableExtensions_Partition
    {
        [Test]
        public void PartitionBySize_partitions_by_max_batch_size()
        {
            var src = new[] {1, 2, 3, 4, 5, 6};
            var expected = new[] {new[] {1, 2}, new[] {3, 4}, new[] {5, 6}};

            Assert.AreEqual(expected, src.PartitionBySize(2));
        }

        [Test]
        public void PartitionBySize_may_return_smaller_last_partition()
        {
            var src = new[] {1, 2, 3, 4, 5};
            var expected = new[] {new[] {1, 2}, new[] {3, 4}, new[] {5}};

            Assert.AreEqual(expected, src.PartitionBySize(2));
        }

        [Test]
        public void PartitionByCount_return_exact_number_of_batches()
        {
            for (var i = 1; i < 100; i++)
            {
                var seq = Enumerable.Range(1, 100).ToList();
                var partitions = seq.PartitionByCount(i);

                Assert.AreEqual(seq, partitions.SelectMany(x => x), "Partitioning missed values");
                Assert.AreEqual(i, partitions.Count, "Partitioning missed count");
            }
        }

        [Test]
        public void PartitionByCount_returns_less_batches_if_not_enough_elements()
        {
            for (var i = 1; i < 100; i++)
            {
                for (var j = 1; j < 10; j++)
                {
                    var seq = Enumerable.Range(1, i).ToList();
                    var partitions = seq.PartitionByCount(i + j);

                    Assert.AreEqual(seq, partitions.SelectMany(x => x), "Partitioning missed values");
                    Assert.AreEqual(i, partitions.Count, "Partitioning missed count");
                }
            }
        }

        [Test]
        public void PartitionBySize_requires_size_greater_than_1()
        {
            Assert.Throws<ArgumentException>(() => new[] {1, 2, 3}.PartitionBySize(0));
            Assert.Throws<ArgumentException>(() => new[] {1, 2, 3}.PartitionBySize(-1));
        }
        
        [Test]
        public void PartitionByCount_requires_count_greater_than_1()
        {
            Assert.Throws<ArgumentException>(() => new[] {1, 2, 3}.PartitionByCount(0));
            Assert.Throws<ArgumentException>(() => new[] {1, 2, 3}.PartitionByCount(-1));
        }
    }
}
