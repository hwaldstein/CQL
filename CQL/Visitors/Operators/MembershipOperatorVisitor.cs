using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Models.Operators;

namespace CQL.Visitors.Operators
{
    public class MembershipOperatorVisitor : CQLBaseVisitor<MembershipOperator>
    {
        public override MembershipOperator VisitIn(CQLParser.InContext context)
        {
            return MembershipOperator.In;
        }

        public override MembershipOperator VisitNotIn(CQLParser.NotInContext context)
        {
            return MembershipOperator.NotIn;
        }
    }
}
