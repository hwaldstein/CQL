using Microsoft.VisualStudio.TestTools.UnitTesting;
using uiowa.maui.api;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace uiowa.maui.api.Tests
{
    [TestClass()]
    public class CourseTests
    {
        private readonly Course _course = new Course();

        [TestMethod()]
        public void GetCourse_DoesNotReturnNull()
        {
            dto.registrar.course.Course course = _course.GetCourse("MATH:3600");
            Assert.IsNotNull(course);
        }
    }
}