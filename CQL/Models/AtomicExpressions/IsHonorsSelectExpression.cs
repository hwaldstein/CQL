using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Enums;
using CQL.Interfaces;
using CQL.Models.Operators;
using Data.Interfaces;

namespace CQL.Models.AtomicExpressions
{
    public class IsHonorsSelectExpression : IAtomicExpression
    {
        private bool isHonors;
        private EquivalenceOperator equivalenceOperator;

        public IsHonorsSelectExpression(bool isHonors, EquivalenceOperator equivalenceOperator)
        {
            this.isHonors = isHonors;
            this.equivalenceOperator = equivalenceOperator;
        }

        public IEnumerable<ICourse> Evaluate(ISource source)
        {
            if ((equivalenceOperator == EquivalenceOperator.Equals && isHonors) || (equivalenceOperator == EquivalenceOperator.NotEquals && !isHonors))
            {
                return source.IsHonors();
            }
            else
            {
                return source.NotHonors();
            }
        }
    }
}
