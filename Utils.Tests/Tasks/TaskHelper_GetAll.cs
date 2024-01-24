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

            Assert.That(i1, Is.EqualTo(1));
            Assert.That(i2, Is.EqualTo(2));
        }

        [Test]
        public async Task GetAll_returns_3_values()
        {
            var (i1, i2, i3) = await TaskHelper.GetAll(
                Task.FromResult(1),
                Task.FromResult(2),
                Task.FromResult(3)
            );

            Assert.That(i1, Is.EqualTo(1));
            Assert.That(i2, Is.EqualTo(2));
            Assert.That(i3, Is.EqualTo(3));
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

            Assert.That(i1, Is.EqualTo(1));
            Assert.That(i2, Is.EqualTo(2));
            Assert.That(i3, Is.EqualTo(3));
            Assert.That(i4, Is.EqualTo(4));
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

            Assert.That(i1, Is.EqualTo(1));
            Assert.That(i2, Is.EqualTo(2));
            Assert.That(i3, Is.EqualTo(3));
            Assert.That(i4, Is.EqualTo(4));
            Assert.That(i5, Is.EqualTo(5));
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

            Assert.That(i1, Is.EqualTo(1));
            Assert.That(i2, Is.EqualTo(2));
            Assert.That(i3, Is.EqualTo(3));
            Assert.That(i4, Is.EqualTo(4));
            Assert.That(i5, Is.EqualTo(5));
            Assert.That(i6, Is.EqualTo(6));
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

            Assert.That(i1, Is.EqualTo(1));
            Assert.That(i2, Is.EqualTo(2));
            Assert.That(i3, Is.EqualTo(3));
            Assert.That(i4, Is.EqualTo(4));
            Assert.That(i5, Is.EqualTo(5));
            Assert.That(i6, Is.EqualTo(6));
            Assert.That(i7, Is.EqualTo(7));
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
