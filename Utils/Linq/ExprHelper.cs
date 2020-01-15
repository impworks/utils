using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Impworks.Utils.Linq
{
    /// <summary>
    /// Helper methods for working with expressions.
    /// </summary>
    public static class ExprHelper
    {
        #region Disjunction

        /// <summary>
        /// Returns a predicate that is true if any of the given predicates are true (OR).
        /// </summary>
        /// <param name="predicates">List of predicates to combine.</param>
        public static Expression<Func<T, bool>> Or<T>(params Expression<Func<T, bool>>[] predicates)
        {
            return Or(predicates.AsEnumerable());
        }

        /// <summary>
        /// Returns a predicate that is true if any of the given predicates are true (OR).
        /// </summary>
        /// <param name="predicates">List of predicates to combine.</param>
        public static Expression<Func<T, bool>> Or<T>(IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            return Combine(predicates, Expression.Or);
        }

        #endregion

        #region Conjunction

        /// <summary>
        /// Returns a predicate that is true if all of the given predicates are true (AND).
        /// </summary>
        /// <param name="predicates">List of predicates to combine.</param>
        public static Expression<Func<T, bool>> And<T>(params Expression<Func<T, bool>>[] predicates)
        {
            return And(predicates.AsEnumerable());
        }

        /// <summary>
        /// Returns a predicate that is true if all of the given predicates are true (AND).
        /// </summary>
        /// <param name="predicates">List of predicates to combine.</param>
        public static Expression<Func<T, bool>> And<T>(IEnumerable<Expression<Func<T, bool>>> predicates)
        {
            return Combine(predicates, Expression.And);
        }

        #endregion

        #region Implementation

        /// <summary>
        /// Combines expressions using a binary operator.
        /// </summary>
        private static Expression<Func<T, bool>> Combine<T>(IEnumerable<Expression<Func<T, bool>>> predicates, Func<Expression, Expression, Expression> combinator)
        {
            if (predicates == null)
                throw new ArgumentNullException(nameof(predicates));
            if (combinator == null)
                throw new ArgumentNullException(nameof(combinator));

            var arg = Expression.Parameter(typeof(T), "arg");

            var curr = null as Expression;
            foreach (var pred in predicates)
            {
                var fixedPred = new ParameterReplacerVisitor(pred.Parameters.Single(), arg).VisitAndConvert(pred, nameof(Combine));
                curr = curr == null ? fixedPred.Body : combinator(curr, fixedPred.Body);
            }

            if(curr == null)
                throw new ArgumentException("No predicates have been specified!", nameof(predicates));

            return Expression.Lambda<Func<T, bool>>(curr, arg);
        }

        /// <summary>
        /// Helper visitor class for replacing a parameter with a specified expression.
        /// </summary>
        private class ParameterReplacerVisitor : ExpressionVisitor
        {
            public ParameterReplacerVisitor(ParameterExpression source, ParameterExpression target)
            {
                _source = source ?? throw new ArgumentNullException(nameof(source));
                _target = target ?? throw new ArgumentNullException(nameof(target));
            }

            private readonly ParameterExpression _source;
            private readonly ParameterExpression _target;

            protected override Expression VisitLambda<T>(Expression<T> node) => Expression.Lambda<T>(Visit(node.Body), _target);
            protected override Expression VisitParameter(ParameterExpression node) => node == _source ? _target : base.VisitParameter(node);
        }

        #endregion
    }
}
