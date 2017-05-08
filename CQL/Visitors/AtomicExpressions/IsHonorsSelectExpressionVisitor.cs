using CQL.Models.AtomicExpressions;
using CQL.Models.Operators;
using CQL.Visitors.Operators;

namespace CQL.Visitors.AtomicExpressions
{
    public class IsHonorsSelectExpressionVisitor : CQLBaseVisitor<IsHonorsSelectExpression>
    {
        public override IsHonorsSelectExpression VisitIsHonorsSelectExpression(CQLParser.IsHonorsSelectExpressionContext context)
        {
            bool booleanValue = context.@bool().Accept(new BooleanVisitor());
            EquivalenceOperator equivalenceOperator =
                context.equivalenceOperator().Accept(new EquivalenceOperatorVisitor());
            return new IsHonorsSelectExpression(booleanValue, equivalenceOperator);
        }
    }
}
