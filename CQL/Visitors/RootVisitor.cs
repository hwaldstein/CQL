using System.Linq;
using CQL.Enums;
using CQL.Models;
using Data.Interfaces;
using Data.Models.Session;
using Data.Sources;

namespace CQL.Visitors
{
    public class RootVisitor : CQLBaseVisitor<Root>
    {
        public override Root VisitRoot(CQLParser.RootContext context)
        {
            Expression expression = context.expression().Accept(new ExpressionVisitor());
            ISource source = null;
            if (context.source() == null)
            {
                //source = new SessionApi(Season.FALL, 2017);
                source = new Spring2017Context();
            }
            else
            {
                source = context.source().Accept(new SourceVisitor());
            }
            OrderByType orderBy;
            if (context.order() == null)
            {
                orderBy = OrderByType.Default;
            }
            else
            {
                orderBy = context.OrderBy().Accept(new OrderByVisitor());
            }
            int? limit = null;
            if (context.number() != null && context.number().Digit() != null && context.number().Digit()?.Length > 0)
            {
                limit = int.Parse(context.number().Digit().Aggregate("", (current, terminalNode) => current + terminalNode.ToString()));
            }
            return new Root(expression, source, orderBy, limit);
        }
    }
}
