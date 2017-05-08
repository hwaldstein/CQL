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
    public class DepartmentSelectExpression : IAtomicExpression
    {
        private AtomicExpressionType type;

        private Department department;
        private EquivalenceOperator equivalenceOperator;

        private IEnumerable<Department> departments;
        private MembershipOperator membershipOperator;

        public DepartmentSelectExpression(Department department, EquivalenceOperator equivalenceOperator)
        {
            this.type = AtomicExpressionType.Equivalence;
            this.department = department;
            this.equivalenceOperator = equivalenceOperator;
        }

        public DepartmentSelectExpression(IEnumerable<Department> departments, MembershipOperator membershipOperator)
        {
            this.type = AtomicExpressionType.Membership;
            this.departments = departments;
            this.membershipOperator = membershipOperator;
        }

        public IEnumerable<ICourse> Evaluate(ISource source)
        {
            switch (this.type)
            {
                case AtomicExpressionType.Equivalence:
                    if (equivalenceOperator == EquivalenceOperator.Equals)
                    {
                        return source.IsDepartment(department);
                    }
                    else
                    {
                        return source.NotDepartment(department);
                    }
                case AtomicExpressionType.Membership:
                    if (membershipOperator == MembershipOperator.In)
                    {
                        HashSet<ICourse> courses = new HashSet<ICourse>();
                        foreach (Department department1 in departments)
                        {
                            var d = source.IsDepartment(department1);
                            courses.UnionWith(d);
                        }
                        return courses;
                    }
                    else
                    {
                        IList<Department> c = Enum.GetValues(typeof(Department)).Cast<Department>().Where(de => !departments.Contains(de)).ToList();

                        // consider symmetric except
                        HashSet<ICourse> courses = new HashSet<ICourse>();
                        foreach (Department department1 in c)
                        {
                            IEnumerable<ICourse> d = source.IsDepartment(department1);
                            courses.UnionWith(d);
                        }
                        return courses;
                    }
                // Everything below this should be unreachable
                case AtomicExpressionType.Inequality:
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
