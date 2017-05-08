using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CQL.Enums;
using CQL.Interfaces;
using CQL.Models.Operators;
using Data.Enums;
using Data.Interfaces;

namespace CQL.Models.AtomicExpressions
{
    public class GenEdSelectExpression : IAtomicExpression
    {
        private AtomicExpressionType type;

        private GenEd genEd;
        private EquivalenceOperator equivalenceOperator;

        private IEnumerable<GenEd> genEds;
        private MembershipOperator membershipOperator;

        public GenEdSelectExpression(GenEd genEd, EquivalenceOperator equivalenceOperator)
        {
            this.type = AtomicExpressionType.Equivalence;
            this.genEd = genEd;
            this.equivalenceOperator = equivalenceOperator;
        }

        public GenEdSelectExpression(IEnumerable<GenEd> genEds, MembershipOperator membershipOperator)
        {
            this.type = AtomicExpressionType.Membership;
            this.genEds = genEds;
            this.membershipOperator = membershipOperator;
        }

        public IEnumerable<ICourse> Evaluate(ISource source)
        {
            switch (type)
            {
                case AtomicExpressionType.Equivalence:
                    if (equivalenceOperator == EquivalenceOperator.Equals)
                    {
                        return source.IsGenEd(genEd);
                    }
                    else
                    {
                        return source.NotGenEd(genEd);
                    }
                case AtomicExpressionType.Membership:
                    if (membershipOperator == MembershipOperator.In)
                    {
                        HashSet<ICourse> courses = new HashSet<ICourse>();
                        foreach (GenEd ed in genEds)
                        {
                            IEnumerable<ICourse> c = source.IsGenEd(ed);
                            courses.UnionWith(c);
                        }
                        return courses;
                    }
                    else
                    {
                        HashSet<ICourse> courses = new HashSet<ICourse>();
                        // consider symmetric except
                        IList<GenEd> gesList = (from GenEd g in Enum.GetValues(typeof(GenEd)) where !genEds.Contains(g) select g).ToList();

                        foreach (GenEd ed in gesList)
                        {
                            IEnumerable<ICourse> c = source.IsGenEd(ed);
                            courses.UnionWith(c);
                        }
                        return courses;
                    }
                case AtomicExpressionType.Inequality:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
