using System;
using System.Collections.Generic;
using System.Linq;
using CQL.Models.AtomicExpressions;
using CQL.Models.Operators;
using CQL.Visitors.Operators;
using Data.Enums;

namespace CQL.Visitors.AtomicExpressions
{
    public class GenEdSelectExpressionVisitor : CQLBaseVisitor<GenEdSelectExpression>
    {
        public override GenEdSelectExpression VisitGenEdEqualsExpr(CQLParser.GenEdEqualsExprContext context)
        {
            GenEd genEd = (GenEd)Enum.Parse(typeof(GenEd), context.GenEd().GetText(), true);
            EquivalenceOperator equivalenceOperator =
                context.equivalenceOperator().Accept(new EquivalenceOperatorVisitor());
            return new GenEdSelectExpression(genEd, equivalenceOperator);
        }

        public override GenEdSelectExpression VisitGenEdListExpr(CQLParser.GenEdListExprContext context)
        {
            List<GenEd> genEds = context.GenEd().Select(terminalNode => (GenEd) Enum.Parse(typeof(GenEd), terminalNode.GetText(), true)).ToList();
            MembershipOperator membershipOperator =
                context.membershipOperator().Accept(new MembershipOperatorVisitor());
            return new GenEdSelectExpression(genEds, membershipOperator);
        }
    }
}
