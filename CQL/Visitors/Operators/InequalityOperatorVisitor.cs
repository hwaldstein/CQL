using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Models.Operators;

namespace CQL.Visitors.Operators
{
    public class InequalityOperatorVisitor : CQLBaseVisitor<InequalityOperator>
    {
        public override InequalityOperator VisitGreaterThan(CQLParser.GreaterThanContext context)
        {
            return InequalityOperator.GreaterThan;
        }

        public override InequalityOperator VisitGreaterThanOrEqualTo(CQLParser.GreaterThanOrEqualToContext context)
        {
            return InequalityOperator.GreaterThanOrEqualTo;
        }

        public override InequalityOperator VisitLessThan(CQLParser.LessThanContext context)
        {
            return InequalityOperator.LessThan;
        }

        public override InequalityOperator VisitLessThanOrEqualTo(CQLParser.LessThanOrEqualToContext context)
        {
            return InequalityOperator.LessThanOrEqualTo;
        }
    }
}