using CQL.Enums;
using CQL.Models;

namespace CQL.Visitors
{
    public class ExpressionVisitor : CQLBaseVisitor<Expression>
    {
        public override Expression VisitParenExpression(CQLParser.ParenExpressionContext context)
        {
            return context.expr.Accept(new ExpressionVisitor());
        }

        public override Expression VisitAndExpression(CQLParser.AndExpressionContext context)
        {
            return new Expression(context.left.Accept(new ExpressionVisitor()), context.right.Accept(new ExpressionVisitor()), ExpressionOperator.And);
        }

        public override Expression VisitOrExpression(CQLParser.OrExpressionContext context)
        {
            return new Expression(context.left.Accept(new ExpressionVisitor()), context.right.Accept(new ExpressionVisitor()), ExpressionOperator.Or);
        }

        public override Expression VisitAtomicExpression(CQLParser.AtomicExpressionContext context)
        {
            return new Expression(context.Accept(new AtomicExpressionVisitor()));
        }
    }
}
