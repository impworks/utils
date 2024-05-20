using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace Impworks.Utils.Tasks;

/// <summary>
/// Async locker that allows waiting by an ID.
/// </summary>
public class Locker<T>
{
    public Locker()
    {
        _locks = new Dictionary<T, SemaphoreWrapper>();
    }

    private readonly Dictionary<T, SemaphoreWrapper> _locks;

    /// <summary>
    /// Acquires a lock, returns an IDisposable that releases it.
    /// </summary>
    public async Task<IDisposable> AcquireAsync(T id, CancellationToken token)
    {
        await WaitAsync(id, token).ConfigureAwait(false);
        return new AcquiredLock(() => Release(id));
    }

    /// <summary>
    /// Waits for the resource to be free.
    /// </summary>
    private Task WaitAsync(T id, CancellationToken token)
    {
        SemaphoreWrapper s;
        lock (_locks)
        {
            if (!_locks.TryGetValue(id, out s))
                s = _locks[id] = new SemaphoreWrapper();
        }

        return s.WaitAsync(token);
    }

    /// <summary>
    /// Frees the occupied resource.
    /// </summary>
    private void Release(T id)
    {
        lock (_locks)
        {
            if (!_locks.TryGetValue(id, out var s))
                return;

            s.Release();

            if (s.PendingCount == 0)
                _locks.Remove(id);
        }
    }

    /// <summary>
    /// Helper class for releasing locks.
    /// </summary>
    private class AcquiredLock : IDisposable
    {
        public AcquiredLock(Action act)
        {
            _act = act;
        }

        private Action _act;

        public void Dispose()
        {
            _act?.Invoke();
            _act = null;
        }
    }

    /// <summary>
    /// Helper class for keeping actual track of pending threads.
    /// </summary>
    private class SemaphoreWrapper
    {
        public SemaphoreWrapper()
        {
            PendingCount = 0;
            Semaphore = new SemaphoreSlim(1, 1);
        }

        public int PendingCount { get; private set; }
        public SemaphoreSlim Semaphore { get; }

        public Task WaitAsync(CancellationToken token)
        {
            PendingCount++;
            return Semaphore.WaitAsync(token);
        }

        public void Release()
        {
            Semaphore.Release();
            PendingCount--;
        }
    }
}