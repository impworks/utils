using System;
using System.Threading.Tasks;
using Impworks.Utils.Exceptions;
using NUnit.Framework;

namespace Utils.Tests.Exceptions
{
    /// <summary>
    /// Tests for Try.Do and Try.DoAsync.
    /// </summary>
    [TestFixture]
    public class Try_Do
    {
        #region Sync

        [Test]
        public void Executes_action_sync()
        {
            var foo = false;

            Try.Do(() => foo = true);

            Assert.That(foo, Is.EqualTo(true));
        }

        [Test]
        public void Catches_exceptions_sync()
        {
            Assert.DoesNotThrow(() => Try.Do(() => throw new Exception()));
        }

        #endregion

        #region Async

        [Test]
        public async Task Executes_action_async()
        {
            var foo = false;

            await Try.DoAsync(async () =>
            {
                await Task.Yield();
                foo = true;
            });

            Assert.That(foo, Is.EqualTo(true));
        }

        [Test]
        public void Catches_exceptions_async()
        {
            Assert.DoesNotThrowAsync(
                async () => await Try.DoAsync(async () =>
                {
                    await Task.Yield();
                    throw new Exception();
                })
            );
        }

        #endregion
    }
}
