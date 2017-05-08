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
    public class CourseNumberSelectExpression : IAtomicExpression
    {
        private AtomicExpressionType type;

        private IEnumerable<ICourse> results; 

        private int courseNumber;
        private EquivalenceOperator equivalenceOperator;
        private InequalityOperator inequalityOperator;

        private IEnumerable<int> courseNumbers;
        private MembershipOperator membershipOperator;

        public CourseNumberSelectExpression(int courseNumber, EquivalenceOperator equivalenceOperator)
        {
            this.type = AtomicExpressionType.Equivalence;
            this.courseNumber = courseNumber;
            this.equivalenceOperator = equivalenceOperator;
        }

        public CourseNumberSelectExpression(IEnumerable<int> courseNumbers, MembershipOperator membershipOperator)
        {
            this.type = AtomicExpressionType.Membership;
            this.courseNumbers = courseNumbers;
            this.membershipOperator = membershipOperator;
        }

        public CourseNumberSelectExpression(int courseNumber, InequalityOperator inequalityOperator)
        {
            this.type = AtomicExpressionType.Inequality;
            this.courseNumber = courseNumber;
            this.inequalityOperator = inequalityOperator;
        }

        public IEnumerable<ICourse> Evaluate(ISource source)
        {
            switch (type)
            {
                case AtomicExpressionType.Equivalence:
                    if (equivalenceOperator == EquivalenceOperator.Equals)
                    {
                        results = source.IsCourseNumber(courseNumber);
                        return results;
                    }
                    else
                    {
                        results = source.NotCourseNumber(courseNumber);
                        return results;
                    }
                case AtomicExpressionType.Membership:
                    if (membershipOperator == MembershipOperator.In)
                    {
                        HashSet<ICourse> courses = new HashSet<ICourse>();
                        foreach (int number in courseNumbers)
                        {
                            IEnumerable<ICourse> c = source.IsCourseNumber(number);
                            courses = courses.Concat(c) as HashSet<ICourse>;
                        }
                        results = courses;
                        return results;
                    }
                    else
                    {
                        HashSet<ICourse> courses = new HashSet<ICourse>();
                        foreach (int number in courseNumbers)
                        {
                            IEnumerable<ICourse> c = source.IsCourseNumber(number);
                            courses.SymmetricExceptWith(c);
                        }
                        results = courses;
                        return results;
                    }
                case AtomicExpressionType.Inequality:
                    if (inequalityOperator == InequalityOperator.GreaterThan)
                    {
                        results = source.GreaterThanCourseNumber(courseNumber);
                        return results;
                    }
                    else if (inequalityOperator == InequalityOperator.GreaterThanOrEqualTo)
                    {
                        results = source.GreaterThanOrEqualToCourseNumber(courseNumber);
                        return results;
                    }
                    else if (inequalityOperator == InequalityOperator.LessThan)
                    {
                        results = source.LessThanCourseNumber(courseNumber);
                        return results;
                    }
                    else
                    {
                        results = source.LessThanOrEqualToCourseNumber(courseNumber);
                        return results;
                    }
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}
