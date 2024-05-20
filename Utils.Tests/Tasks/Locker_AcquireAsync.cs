using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Impworks.Utils.Linq;
using Impworks.Utils.Tasks;
using NUnit.Framework;

namespace Utils.Tests.Tasks
{
    [TestFixture]
    public class Locker_AcquireAsync
    {
        [Test]
        public async Task AcquireAsync_locks_by_id()
        {
            var locker = new Locker<int>();
            var result = new List<string>();

            await Task.WhenAll(
                Add(1, 0, "a", "b", "c"),
                Add(2, 50, "d", "e", "f"),
                Add(1, 50, "h", "i", "j")
            );
            
            Assert.That(result.JoinString(" "), Is.EqualTo("a d b e c f h i j"));

            async Task Add(int key, int initialDelay, params string[] values)
            {
                await Task.Delay(initialDelay);

                using var _ = await locker.AcquireAsync(key, CancellationToken.None);

                foreach (var v in values)
                {
                    result.Add(v);
                    await Task.Delay(100);
                }
            }
        }

        [Test]
        public async Task AcquireAsync_uses_cancellation_token()
        {
            var locker = new Locker<int>();
            var result = new List<string>();

            await Task.WhenAll(
                Run("a", 0, 300),
                Run("b", 50, 100)
            );

            Assert.That(result.JoinString(" "), Is.EqualTo("ex:b a"));

            async Task Run(string key, int delay, int timeout)
            {
                await Task.Delay(delay);
                var cts = new CancellationTokenSource(timeout);
                try
                {
                    using var _ = await locker.AcquireAsync(1, cts.Token);
                    await Task.Delay(200, CancellationToken.None);
                    result.Add(key);
                }
                catch(Exception ex)
                {
                    Assert.That(ex, Is.InstanceOf<OperationCanceledException>());
                    result.Add("ex:" + key);
                }
            }
        }
    }
}
