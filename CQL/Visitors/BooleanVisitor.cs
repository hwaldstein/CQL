using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQL.Visitors
{
    public class BooleanVisitor : CQLBaseVisitor<bool>
    {
        public override bool VisitTrue(CQLParser.TrueContext context)
        {
            return true;
        }

        public override bool VisitFalse(CQLParser.FalseContext context)
        {
            return false;
        }
    }
}
