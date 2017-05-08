

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using CQL.Enums;
using CQL.Interfaces;
using Data.Interfaces;

namespace CQL.Models
{
    public class Root
    {
        private Expression expression;
        private ISource source;
        private OrderByType orderBy;
        private int? limit;
       
        public Root(Expression expression, ISource source, OrderByType orderBy, int? limit)
        {
            this.expression = expression;
            this.source = source;
            this.orderBy = orderBy;
            this.limit = limit;
        }

        // TODO add Evaluate method
        public IEnumerable<ICourse> Evaluate()
        {
            //return expression.Evaluate(source);
            IEnumerable<ICourse> c = expression.Evaluate(source);
            switch (orderBy)
            {
                case OrderByType.Default:
                    c = c.OrderBy(x => x.Department).ThenBy(x => x.CourseNumber);
                    break;
                case OrderByType.CourseNumberAsc:
                    c = c.OrderBy(x => x.CourseNumber);
                    break;
                case OrderByType.CourseNumberDesc:
                    c = c.OrderByDescending(x => x.CourseNumber);
                    break;
                case OrderByType.DepartmentAsc:
                    c = c.OrderBy(x => x.Department);
                    break;
                case OrderByType.DepartmentDesc:
                    c = c.OrderByDescending(x => x.Department);
                    break;
                case OrderByType.GenEdAsc:
                    c = c.OrderBy(x => x.GenEds);
                    break;
                case OrderByType.GenEdDesc:
                    c = c.OrderByDescending(x => x.GenEds);
                    break;
                case OrderByType.IsHonorsAsc:
                    c = c.OrderBy(x => x.IsHonors);
                    break;
                case OrderByType.IsHonorsDesc:
                    c = c.OrderByDescending(x => x.IsHonors);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
            if (limit != null)
            {
                c = c.Take(limit.Value);
            }
            return c;
        }
    }
}
