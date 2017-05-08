using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Enums;
using CQL.Interfaces;
using Data.Interfaces;

namespace CQL.Models
{
    public class Expression
    {
        private Expression left;
        private Expression right;
        private IAtomicExpression atomicExpression;
        private ExpressionOperator op;

        public Expression(Expression left, Expression right, ExpressionOperator op)
        {
            this.left = left;
            this.right = right;
            this.op = op;
        }

        public Expression(IAtomicExpression expression)
        {
            this.op = ExpressionOperator.None;
            this.atomicExpression = expression;
        }

        public IEnumerable<ICourse> Evaluate(ISource source)
        {
            if (this.op == ExpressionOperator.And)
            {
                return left.Evaluate(source).Intersect(right.Evaluate(source));
            } else if (this.op == ExpressionOperator.Or)
            {
                return left.Evaluate(source).Union(right.Evaluate(source));
            }
            else
            {
                return atomicExpression.Evaluate(source);
            }
        }
    }
}
