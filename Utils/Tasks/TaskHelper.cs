using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Impworks.Utils.Tasks;
#if NETSTANDARD || NET6_0_OR_GREATER
/// <summary>
/// Helper methods for working with tasks.
/// </summary>
public static class TaskHelper
{
    #region GetAll

    /// <summary>
    /// Returns the result of all tasks awaited in parallel.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ValueTuple<T1, T2>> GetAll<T1, T2>(Task<T1> t1, Task<T2> t2)
    {
        await Task.WhenAll(t1, t2).ConfigureAwait(false);
        return (t1.Result, t2.Result);
    }

    /// <summary>
    /// Returns the result of all tasks awaited in parallel.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ValueTuple<T1, T2, T3>> GetAll<T1, T2, T3>(Task<T1> t1, Task<T2> t2, Task<T3> t3)
    {
        await Task.WhenAll(t1, t2, t3).ConfigureAwait(false);
        return (t1.Result, t2.Result, t3.Result);
    }

    /// <summary>
    /// Returns the result of all tasks awaited in parallel.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ValueTuple<T1, T2, T3, T4>> GetAll<T1, T2, T3, T4>(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4)
    {
        await Task.WhenAll(t1, t2, t3, t4).ConfigureAwait(false);
        return (t1.Result, t2.Result, t3.Result, t4.Result);
    }

    /// <summary>
    /// Returns the result of all tasks awaited in parallel.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ValueTuple<T1, T2, T3, T4, T5>> GetAll<T1, T2, T3, T4, T5>(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5)
    {
        await Task.WhenAll(t1, t2, t3, t4, t5).ConfigureAwait(false);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result);
    }

    /// <summary>
    /// Returns the result of all tasks awaited in parallel.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ValueTuple<T1, T2, T3, T4, T5, T6>> GetAll<T1, T2, T3, T4, T5, T6>(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6)
    {
        await Task.WhenAll(t1, t2, t3, t4, t5, t6).ConfigureAwait(false);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result);
    }

    /// <summary>
    /// Returns the result of all tasks awaited in parallel.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static async Task<ValueTuple<T1, T2, T3, T4, T5, T6, T7>> GetAll<T1, T2, T3, T4, T5, T6, T7>(Task<T1> t1, Task<T2> t2, Task<T3> t3, Task<T4> t4, Task<T5> t5, Task<T6> t6, Task<T7> t7)
    {
        await Task.WhenAll(t1, t2, t3, t4, t5, t6, t7).ConfigureAwait(false);
        return (t1.Result, t2.Result, t3.Result, t4.Result, t5.Result, t6.Result, t7.Result);
    }

    #endregion
}
#endif