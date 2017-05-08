using System.Collections.Generic;
using System.Linq;
using CQL.Models.AtomicExpressions;
using CQL.Models.Operators;
using CQL.Visitors.Operators;

namespace CQL.Visitors.AtomicExpressions
{
    public class CourseNumberSelectExpressionVisitor : CQLBaseVisitor<CourseNumberSelectExpression>
    {
        public override CourseNumberSelectExpression VisitCourseNumberEqualsExpr(CQLParser.CourseNumberEqualsExprContext context)
        {
            int courseNumber = int.Parse(context.CourseNumber().GetText());
            EquivalenceOperator equivalenceOperator =
                context.equivalenceOperator().Accept(new EquivalenceOperatorVisitor());
            return new CourseNumberSelectExpression(courseNumber, equivalenceOperator);
        }

        public override CourseNumberSelectExpression VisitCourseNumberListExpr(CQLParser.CourseNumberListExprContext context)
        {
            List<int> courseNumbers = context.CourseNumber().Select(terminalNode => int.Parse(terminalNode.GetText())).ToList();
            MembershipOperator membershipOperator =
                context.membershipOperator().Accept(new MembershipOperatorVisitor());
            return new CourseNumberSelectExpression(courseNumbers, membershipOperator);
        }

        public override CourseNumberSelectExpression VisitCourseNumberInqualityExpr(CQLParser.CourseNumberInqualityExprContext context)
        {
            int courseNumber = int.Parse(context.CourseNumber().GetText());
            InequalityOperator inequalityOperator =
                context.inequalityOperator().Accept(new InequalityOperatorVisitor());
            return new CourseNumberSelectExpression(courseNumber, inequalityOperator);
        }
    }
}
