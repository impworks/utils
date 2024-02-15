using System;
using System.Threading.Tasks;

namespace Impworks.Utils.Exceptions;

/// <summary>
/// Helper methods to ignore exceptions fluently.
/// </summary>
public class Try
{
    #region Sync

    /// <summary>
    /// Invokes the action, ignoring all exceptions.
    /// </summary>
    public static void Do(Action act)
    {
        try
        {
            act();
        }
        catch
        {
            // ignored
        }
    }

    /// <summary>
    /// Returns the value of the function, or the default value in case of an exception.
    /// </summary>
    public static T Get<T>(Func<T> generator)
    {
        try
        {
            return generator();
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Returns the value of the function, or the fallback value in case of an exception.
    /// </summary>
    public static T Get<T>(Func<T> generator, T fallback)
    {
        try
        {
            return generator();
        }
        catch
        {
            return fallback;
        }
    }

    /// <summary>
    /// Returns the value of the first function that does not throw an exception, or the default value.
    /// </summary>
    public static T Get<T>(params Func<T>[] generators)
    {
        foreach (var generator in generators)
        {
            try
            {
                return generator();
            }
            catch
            {
                // ignore
            }
        }

        return default;
    }

    #endregion

    #region Async

    /// <summary>
    /// Invokes the action, ignoring all exceptions.
    /// </summary>
    public static async Task DoAsync(Func<Task> act)
    {
        try
        {
            await act().ConfigureAwait(false);
        }
        catch
        {
            // ignored
        }
    }

    /// <summary>
    /// Returns the value of the task, or the default value in case of an exception.
    /// </summary>
    public static async Task<T> GetAsync<T>(Func<Task<T>> generator)
    {
        try
        {
            return await generator().ConfigureAwait(false);
        }
        catch
        {
            return default;
        }
    }

    /// <summary>
    /// Returns the value of the task, or the fallback value in case of an exception.
    /// </summary>
    public static async Task<T> GetAsync<T>(Func<Task<T>> generator, T fallback)
    {
        try
        {
            return await generator().ConfigureAwait(false);
        }
        catch
        {
            return fallback;
        }
    }

    /// <summary>
    /// Returns the value of the first task that does not throw an exception, or the default value.
    /// </summary>
    public static async Task<T> GetAsync<T>(params Func<Task<T>>[] generators)
    {
        foreach (var generator in generators)
        {
            try
            {
                return await generator().ConfigureAwait(false);
            }
            catch
            {
                // ignore
            }
        }

        return default;
    }

    #endregion
}