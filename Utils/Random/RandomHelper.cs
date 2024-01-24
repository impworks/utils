using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Random;

/// <summary>
/// Random value provider.
/// </summary>
public static class RandomHelper
{
    /// <summary>
    /// Underlying random provider.
    /// </summary>
    private static readonly System.Random _random = new System.Random(DateTime.Now.Millisecond);

    /// <summary>
    /// Creates a random number between 0.0 and 1.0.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Float()
    {
        return (float) _random.NextDouble();
    }

    /// <summary>
    /// Creates a random number between two values.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static float Float(float from, float to)
    {
        var scale = to - from;
        return from + (float)_random.NextDouble() * scale;
    }

    /// <summary>
    /// Creates a random number between 0.0 and 1.0.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Double()
    {
        return _random.NextDouble();
    }

    /// <summary>
    /// Creates a random number between two values.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static double Double(double from, double to)
    {
        var scale = to - from;
        return from + _random.NextDouble() * scale;
    }

    /// <summary>
    /// Creates a random integer in the given range.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Int(int from, int to)
    {
        return _random.Next(from, to);
    }

    /// <summary>
    /// Creates a random long integer in the given range.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static long Long(long from, long to)
    {
        var scale = to - from;
        return from + (long) (_random.NextDouble() * scale);
    }

    /// <summary>
    /// Flips a virtual coin.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static bool Bool()
    {
        return _random.NextDouble() > 0.5;
    }

    /// <summary>
    /// Random sign: plus or minus.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static int Sign()
    {
        return _random.NextDouble() > 0.5 ? 1 : -1;
    }

    /// <summary>
    /// Pick a random item from the array.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static T PickAny<T>(params T[] items)
    {
        return Pick(items);
    }

    /// <summary>
    /// Pick a random item from the list.
    /// </summary>
    public static T Pick<T>(IReadOnlyList<T> items)
    {
        if (items.Count == 0)
            return default;

        // works better on bigger numbers
        var id = _random.Next(items.Count * 100);
        return items[id / 100];
    }

    /// <summary>
    /// Picks a random item from the list according to their relative weights.
    /// </summary>
    /// <param name="items">Source item collection.</param>
    /// <param name="weightFunc">
    /// Projection that returns a relative weight of the element.
    /// Elements with bigger weight are more likely to be selected.
    /// </param>
    public static T PickWeighted<T>(IReadOnlyList<T> items, Func<T, double> weightFunc)
    {
        var threshold = Float();
        var list = items.Select(x => new {Value = x, Weight = weightFunc(x)}).ToList();
        var delta = 1.0 / list.Sum(x => x.Weight);
        var prob = 0.0;

        foreach (var elem in list)
        {
            // normalized weight
            prob += elem.Weight * delta;

            if (prob >= threshold)
                return elem.Value;
        }

        return default;
    }
}