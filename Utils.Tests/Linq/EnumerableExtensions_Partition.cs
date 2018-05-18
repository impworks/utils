using System;
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
        public void PartitionByCount_partitions_by_number_of_batches()
        {
            var src = new[] {1, 2, 3, 4, 5, 6};
            var expected = new[] {new[] {1, 2, 3}, new[] {4, 5, 6}};

            Assert.AreEqual(expected, src.PartitionByCount(2));
        }

        [Test]
        public void PartitionByCount_may_return_smaller_last_partition()
        {
            var src = new[] {1, 2, 3, 4, 5};
            var expected = new[] {new[] {1, 2, 3}, new[] {4, 5}};

            Assert.AreEqual(expected, src.PartitionByCount(2));
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
