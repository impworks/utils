using System;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;

namespace Impworks.Utils.Linq;

public static partial class ExprHelper
{
    #region Func

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<TResult>> Apply<T1, TResult>(Expression<Func<T1, TResult>> expr, T1 arg)
        => ApplyInternal<Func<TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, TResult>> Apply<T1, T2, TResult>(Expression<Func<T1, T2, TResult>> expr, T2 arg)
        => ApplyInternal<Func<T1, TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, T2, TResult>> Apply<T1, T2, T3, TResult>(Expression<Func<T1, T2, T3, TResult>> expr, T3 arg)
        => ApplyInternal<Func<T1, T2, TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, T2, T3, TResult>> Apply<T1, T2, T3, T4, TResult>(Expression<Func<T1, T2, T3, T4, TResult>> expr, T4 arg)
        => ApplyInternal<Func<T1, T2, T3, TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, T2, T3, T4, TResult>> Apply<T1, T2, T3, T4, T5, TResult>(Expression<Func<T1, T2, T3, T4, T5, TResult>> expr, T5 arg)
        => ApplyInternal<Func<T1, T2, T3, T4, TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, T2, T3, T4, T5, TResult>> Apply<T1, T2, T3, T4, T5, T6, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> expr, T6 arg)
        => ApplyInternal<Func<T1, T2, T3, T4, T5, TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, T2, T3, T4, T5, T6, TResult>> Apply<T1, T2, T3, T4, T5, T6, T7, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> expr, T7 arg)
        => ApplyInternal<Func<T1, T2, T3, T4, T5, T6, TResult>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Func<T1, T2, T3, T4, T5, T6, T7, TResult>> Apply<T1, T2, T3, T4, T5, T6, T7, T8, TResult>(Expression<Func<T1, T2, T3, T4, T5, T6, T7, T8, TResult>> expr, T8 arg)
        => ApplyInternal<Func<T1, T2, T3, T4, T5, T6, T7, TResult>>(expr, arg);

    #endregion

    #region Action

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action> Apply<T1>(Expression<Action<T1>> expr, T1 arg)
        => ApplyInternal<Action>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1>> Apply<T1, T2>(Expression<Action<T1, T2>> expr, T2 arg)
        => ApplyInternal<Action<T1>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1, T2>> Apply<T1, T2, T3>(Expression<Action<T1, T2, T3>> expr, T3 arg)
        => ApplyInternal<Action<T1, T2>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1, T2, T3>> Apply<T1, T2, T3, T4>(Expression<Action<T1, T2, T3, T4>> expr, T4 arg)
        => ApplyInternal<Action<T1, T2, T3>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1, T2, T3, T4>> Apply<T1, T2, T3, T4, T5>(Expression<Action<T1, T2, T3, T4, T5>> expr, T5 arg)
        => ApplyInternal<Action<T1, T2, T3, T4>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1, T2, T3, T4, T5>> Apply<T1, T2, T3, T4, T5, T6>(Expression<Action<T1, T2, T3, T4, T5, T6>> expr, T6 arg)
        => ApplyInternal<Action<T1, T2, T3, T4, T5>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1, T2, T3, T4, T5, T6>> Apply<T1, T2, T3, T4, T5, T6, T7>(Expression<Action<T1, T2, T3, T4, T5, T6, T7>> expr, T7 arg)
        => ApplyInternal<Action<T1, T2, T3, T4, T5, T6>>(expr, arg);

    /// <summary>
    /// Applies an argument to the expression.
    /// </summary>
    [MethodImpl(MethodImplOptions.AggressiveInlining)]
    public static Expression<Action<T1, T2, T3, T4, T5, T6, T7>> Apply<T1, T2, T3, T4, T5, T6, T7, T8>(Expression<Action<T1, T2, T3, T4, T5, T6, T7, T8>> expr, T8 arg)
        => ApplyInternal<Action<T1, T2, T3, T4, T5, T6, T7>>(expr, arg);

    #endregion

    #region Implementation

    /// <summary>
    /// Performs application.
    /// </summary>
    private static Expression<T> ApplyInternal<T>(LambdaExpression lambda, object arg)
    {
        if(lambda == null)
            throw new ArgumentNullException(nameof(lambda));

        var visitor = new ReplaceParameterByExpressionVisitor(lambda.Parameters.Last(), Expression.Constant(arg));
        return (Expression<T>) visitor.Visit(lambda);
    }

    /// <summary>
    /// Visitor class for replacing a lambda parameter with an expression.
    /// </summary>
    private class ReplaceParameterByExpressionVisitor : ExpressionVisitor
    {
        public ReplaceParameterByExpressionVisitor(ParameterExpression source, Expression target)
        {
            _source = source ?? throw new ArgumentNullException(nameof(source));
            _target = target ?? throw new ArgumentNullException(nameof(target));

            if (_target is ConstantExpression {Value: null})
                _target = Expression.Convert(_target, _source.Type);
        }

        private readonly ParameterExpression _source;
        private readonly Expression _target;

        protected override Expression VisitLambda<T>(Expression<T> node) => Expression.Lambda(Visit(node.Body), node.Parameters.Where(x => x != _source));
        protected override Expression VisitParameter(ParameterExpression node) => node == _source ? _target : base.VisitParameter(node);
    }

    #endregion
}