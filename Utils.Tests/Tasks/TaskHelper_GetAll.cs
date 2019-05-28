using System;
using System.Threading.Tasks;
using Impworks.Utils.Tasks;
using NUnit.Framework;

namespace Utils.Tests.Tasks
{
    /// <summary>
    /// Tests for TaskHelper.GetAll.
    /// </summary>
    [TestFixture]
    public class TaskHelper_GetAll
    {
        [Test]
        public async Task GetAll_returns_2_values()
        {
            var (i1, i2) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2)
            );

            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
        }

        [Test]
        public async Task GetAll_returns_3_values()
        {
            var (i1, i2, i3) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2),
                Task.FromResult(3)
            );

            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
            Assert.AreEqual(3, i3);
        }

        [Test]
        public async Task GetAll_returns_4_values()
        {
            var (i1, i2, i3, i4) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2),
                Task.FromResult(3),
                Task.FromResult(4)
            );

            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
            Assert.AreEqual(3, i3);
            Assert.AreEqual(4, i4);
        }

        [Test]
        public async Task GetAll_returns_5_values()
        {
            var (i1, i2, i3, i4, i5) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2),
                Task.FromResult(3),
                Task.FromResult(4),
                Task.FromResult(5)
            );

            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
            Assert.AreEqual(3, i3);
            Assert.AreEqual(4, i4);
            Assert.AreEqual(5, i5);
        }

        [Test]
        public async Task GetAll_returns_6_values()
        {
            var (i1, i2, i3, i4, i5, i6) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2),
                Task.FromResult(3),
                Task.FromResult(4),
                Task.FromResult(5),
                Task.FromResult(6)
            );

            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
            Assert.AreEqual(3, i3);
            Assert.AreEqual(4, i4);
            Assert.AreEqual(5, i5);
            Assert.AreEqual(6, i6);
        }

        [Test]
        public async Task GetAll_returns_7_values()
        {
            var (i1, i2, i3, i4, i5, i6, i7) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2),
                Task.FromResult(3),
                Task.FromResult(4),
                Task.FromResult(5),
                Task.FromResult(6),
                Task.FromResult(7)
            );

            Assert.AreEqual(1, i1);
            Assert.AreEqual(2, i2);
            Assert.AreEqual(3, i3);
            Assert.AreEqual(4, i4);
            Assert.AreEqual(5, i5);
            Assert.AreEqual(6, i6);
            Assert.AreEqual(7, i7);
        }

        [Test]
        public void GetAll_throws_exception_if_task_failed()
        {
            Assert.ThrowsAsync<NotImplementedException>(async () =>
            {
                await TaskHelper.GetAll(
                    Task.FromResult(1),
                    Task.FromException<int>(new NotImplementedException())
                );
            });
        }
    }
}
