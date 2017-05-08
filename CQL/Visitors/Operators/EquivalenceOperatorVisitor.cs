using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Models.Operators;

namespace CQL.Visitors.Operators
{
    public class EquivalenceOperatorVisitor : CQLBaseVisitor<EquivalenceOperator>
    {
        public override EquivalenceOperator VisitEq(CQLParser.EqContext context)
        {
            return EquivalenceOperator.Equals;
        }

        public override EquivalenceOperator VisitNotEq(CQLParser.NotEqContext context)
        {
            return EquivalenceOperator.NotEquals;
        }
    }
}
