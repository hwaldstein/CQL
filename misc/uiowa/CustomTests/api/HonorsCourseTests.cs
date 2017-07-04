using Microsoft.VisualStudio.TestTools.UnitTesting;
using Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uiowa.maui.api;

namespace Custom.Tests
{
    [TestClass()]
    public class HonorsCourseTests
    {
        private readonly HonorsCourse _course = new HonorsCourse();
        [TestMethod()]
        public void GetHonorsCourses_DoesNotReturnNull()
        {
            //var sessionId = (new Session()).FindCurrent().id;
            var sessionId = 68;
            var courses = _course.GetHonorsCourses(sessionId);
            Assert.IsNotNull(courses);
        }
    }
}