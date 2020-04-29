using System;
using System.Linq;
using System.Linq.Expressions;

namespace Impworks.Utils.Linq
{
    public static partial class ExprHelper
    {
        /// <summary>
        /// Helper visitor class for replacing one parameter with another.
        /// </summary>
        private class ReplaceParameterByParameterVisitor : ExpressionVisitor
        {
            public ReplaceParameterByParameterVisitor(ParameterExpression source, ParameterExpression target)
            {
                _source = source ?? throw new ArgumentNullException(nameof(source));
                _target = target ?? throw new ArgumentNullException(nameof(target));
            }

            private readonly ParameterExpression _source;
            private readonly ParameterExpression _target;

            protected override Expression VisitLambda<T>(Expression<T> node) => Expression.Lambda<T>(Visit(node.Body), _target);
            protected override Expression VisitParameter(ParameterExpression node) => node == _source ? _target : base.VisitParameter(node);
        }
    }
}
