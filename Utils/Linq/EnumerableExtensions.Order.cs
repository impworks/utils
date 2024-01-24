using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Linq;

public static partial class EnumerableExtensions
{
    /// <summary>
    /// Orders the sequence by a field with direction based on a flag.
    /// </summary>
    /// <param name="source">The sequence of values.</param>
    /// <param name="orderExpr">Descriptor of the property to use for sorting.</param>
    /// <param name="isDescending">Order direction flag.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IOrderedEnumerable<T> OrderBy<T, T2>(this IEnumerable<T> source, Func<T, T2> orderExpr, bool isDescending)
    {
        return isDescending
            ? source.OrderByDescending(orderExpr)
            : source.OrderBy(orderExpr);
    }

    /// <summary>
    /// Orders the sequence by a field with direction based on a flag.
    /// </summary>
    /// <param name="source">The sequence of values.</param>
    /// <param name="orderExpr">Descriptor of the property to use for sorting.</param>
    /// <param name="isDescending">Order direction flag.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IOrderedEnumerable<T> ThenBy<T, T2>(this IOrderedEnumerable<T> source, Func<T, T2> orderExpr, bool isDescending)
    {
        return isDescending
            ? source.ThenByDescending(orderExpr)
            : source.ThenBy(orderExpr);
    }

    /// <summary>
    /// Orders the query by a field with direction based on a flag.
    /// </summary>
    /// <param name="source">The sequence of values.</param>
    /// <param name="orderExpr">Descriptor of the property to use for sorting.</param>
    /// <param name="isDescending">Order direction flag.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IOrderedQueryable<T> OrderBy<T, T2>(this IQueryable<T> source, Expression<Func<T, T2>> orderExpr, bool isDescending)
    {
        return isDescending
            ? source.OrderByDescending(orderExpr)
            : source.OrderBy(orderExpr);
    }

    /// <summary>
    /// Orders the query by a field with direction based on a flag.
    /// </summary>
    /// <param name="source">The sequence of values.</param>
    /// <param name="orderExpr">Descriptor of the property to use for sorting.</param>
    /// <param name="isDescending">Order direction flag.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IOrderedQueryable<T> ThenBy<T, T2>(this IOrderedQueryable<T> source, Expression<Func<T, T2>> orderExpr, bool isDescending)
    {
        return isDescending
            ? source.ThenByDescending(orderExpr)
            : source.ThenBy(orderExpr);
    }

    /// <summary>
    /// Orders the query by a field name with direction based on a flag.
    /// </summary>
    /// <param name="source">The sequence of values.</param>
    /// <param name="propName">Name of the property to use for sorting.</param>
    /// <param name="isDescending">Order direction flag.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IOrderedQueryable<T> OrderBy<T>(this IQueryable<T> source, string propName, bool isDescending)
    {
        var method = isDescending ? OrderMethods.OrderByDescending : OrderMethods.OrderBy;
        return OrderByInternal(source, propName, method);
    }

    /// <summary>
    /// Orders the query by a field name with direction based on a flag.
    /// </summary>
    /// <param name="source">The sequence of values.</param>
    /// <param name="propName">Name of the property to use for sorting.</param>
    /// <param name="isDescending">Order direction flag.</param>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static IOrderedQueryable<T> ThenBy<T>(this IOrderedQueryable<T> source, string propName, bool isDescending)
    {
        var method = isDescending ? OrderMethods.ThenByDescending : OrderMethods.ThenBy;
        return OrderByInternal(source, propName, method);
    }

    #region Private helpers

    /// <summary>
    /// The cached references to ordering methods.
    /// </summary>
    private static class OrderMethods
    {
        static OrderMethods()
        {
            var methods = typeof(Queryable).GetMethods()
                                           .Where(x => x.GetParameters().Length == 2
                                                       && (x.Name.StartsWith("OrderBy") || x.Name.StartsWith("ThenBy")))
                                           .ToDictionary(x => x.Name, x => x);

            OrderBy = methods[nameof(OrderBy)];
            OrderByDescending = methods[nameof(OrderByDescending)];
            ThenBy = methods[nameof(ThenBy)];
            ThenByDescending = methods[nameof(ThenByDescending)];
        }

        public static readonly MethodInfo OrderBy;
        public static readonly MethodInfo OrderByDescending;
        public static readonly MethodInfo ThenBy;
        public static readonly MethodInfo ThenByDescending;
    }

    /// <summary>
    /// Applies the arbitrary ordering method with arbitrary property.
    /// </summary>
    private static IOrderedQueryable<T> OrderByInternal<T>(IQueryable<T> source, string propName, MethodInfo method)
    {
        var arg = Expression.Parameter(typeof(T), "x");
        var expr = (Expression) arg;
        var type = typeof(T);

        var parts = propName.Split('.');
        foreach (var part in parts)
        {
            var propType = type.GetProperty(part)?.PropertyType
                           ?? type.GetField(part)?.FieldType;

            if(propType == null)
                throw new ArgumentException($"Invalid property path ('{propName}'): type '{type.Name}' has no property or field named '{part}'.");

            expr = Expression.PropertyOrField(expr, part);
            type = propType;
        }

        var lambda = Expression.Lambda(expr, arg);
        var query = source.Provider.CreateQuery(
            Expression.Call(
                null,
                method.MakeGenericMethod(typeof(T), type),
                [
                    source.Expression,
                    Expression.Quote(lambda)
                ]
            )
        );

        return (IOrderedQueryable<T>) query;
    }

    #endregion
}