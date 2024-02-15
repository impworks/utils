using System;
using System.Threading.Tasks;
using Impworks.Utils.Exceptions;
using NUnit.Framework;

namespace Utils.Tests.Exceptions
{
    /// <summary>
    /// Tests for Try.Get and Try.GetAsync.
    /// </summary>
    [TestFixture]
    public class Try_Get
    {
        #region Sync

        [Test]
        public void Returns_value_sync()
        {
            Assert.That(Try.Get(() => 1), Is.EqualTo(1));
        }

        [Test]
        public void Returns_default_sync()
        {
            Assert.That(Try.Get<int>(() => throw new Exception()), Is.EqualTo(0));
        }

        [Test]
        public void Returns_fallback_sync()
        {
            Assert.That(Try.Get(() => throw new Exception(), 2), Is.EqualTo(2));
        }

        [Test]
        public void Returns_first_non_throwing_sync()
        {
            Assert.That(
                Try.Get(
                    () => throw new Exception(),
                    () => throw new NotImplementedException(),
                    () => 2,
                    () => 3
                ),
                Is.EqualTo(2)
            );
        }

        [Test]
        public void Returns_default_multiple_sync()
        {
            Assert.That(
                Try.Get<int>(
                    () => throw new Exception(),
                    () => throw new NotImplementedException()
                ),
                Is.EqualTo(0)
            );
        }

        #endregion

        #region Async

        [Test]
        public async Task Returns_value_async()
        {
            Assert.That(
                await Try.GetAsync(async () =>
                {
                    await Task.Yield();
                    return 1;
                }),
                Is.EqualTo(1)
            );
        }

        [Test]
        public async Task Returns_default_async()
        {
            Assert.That(
                await Try.GetAsync<int>(async () =>
                {
                    await Task.Yield();
                    throw new Exception();
                }),
                Is.EqualTo(0)
            );
        }

        [Test]
        public async Task Returns_fallback_async()
        {
            Assert.That(
                await Try.GetAsync(
                    async () =>
                    {
                        await Task.Yield();
                        throw new Exception();
                    },
                    2),
                Is.EqualTo(2)
            );
        }

        [Test]
        public async Task Returns_first_non_throwing_async()
        {
            Assert.That(
                await Try.GetAsync(
                    async () =>
                    {
                        await Task.Yield();
                        throw new Exception();
                    },
                    async () =>
                    {
                        await Task.Yield();
                        throw new NotImplementedException();
                    },
                    async () =>
                    {
                        await Task.Yield();
                        return 2;
                    },
                    async () =>
                    {
                        await Task.Yield();
                        return 3;
                    }),
                Is.EqualTo(2)
            );
        }

        [Test]
        public async Task Returns_default_multiple_async()
        {
            Assert.That(
                await Try.GetAsync<int>(
                    async () =>
                    {
                        await Task.Yield();
                        throw new Exception();
                    },
                    async () =>
                    {
                        await Task.Yield();
                        throw new NotImplementedException();
                    }),
                Is.EqualTo(0)
            );
        }

        #endregion
    }
}
