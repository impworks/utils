using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Impworks.Utils.Tasks
{
    /// <summary>
    /// Utility methods for working with tasks.
    /// </summary>
    public static class TaskHelper
    {
        #region Public methods

        /// <summary>
        /// Runs tasks with specified maximum degree of parallelism.
        /// </summary>
        /// <param name="tasks">Tasks to execute in parallel.</param>
        /// <param name="threadCount">Maximum number of parallel threads. Defaults to the number of processors.</param>
        public static async Task<T[]> WhenAll<T>(IEnumerable<Task<T>> tasks, int? threadCount = null)
        {
            var semaphore = CreateSemaphore(threadCount);
            return await Task.WhenAll(tasks.Select(t => ProcessTaskWithSemaphore(t, semaphore)));
        }

        /// <summary>
        /// Runs tasks with specified maximum degree of parallelism.
        /// </summary>
        /// <param name="tasks">Tasks to execute in parallel.</param>
        /// <param name="threadCount">Maximum number of parallel threads. Defaults to the number of processors.</param>
        public static async Task WhenAll(IEnumerable<Task> tasks, int? threadCount = null)
        {
            var semaphore = CreateSemaphore(threadCount);
            await Task.WhenAll(tasks.Select(t => ProcessTaskWithSemaphore(t, semaphore)));
        }

        #endregion

        #region Private helpers

        /// <summary>
        /// Creates the semaphore for the specified number of threads.
        /// </summary>
        private static SemaphoreSlim CreateSemaphore(int? threads)
        {
            var count = threads ?? Environment.ProcessorCount;
            return new SemaphoreSlim(count, count);
        }

        /// <summary>
        /// Processes task with limited parallelism using a semaphore.
        /// </summary>
        private static async Task<T> ProcessTaskWithSemaphore<T>(Task<T> task, SemaphoreSlim semaphore)
        {
            await semaphore.WaitAsync();

            try
            {
                return await task;
            }
            finally
            {
                semaphore.Release();
            }
        }

        /// <summary>
        /// Processes task with limited parallelism using a semaphore.
        /// </summary>
        private static async Task ProcessTaskWithSemaphore(Task task, SemaphoreSlim semaphore)
        {
            await semaphore.WaitAsync();

            try
            {
                await task;
            }
            finally
            {
                semaphore.Release();
            }
        }

        #endregion
    }
}
