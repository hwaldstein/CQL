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
    public class AcademicUnitTests
    {
        private readonly AcademicUnit _academicUnit = new AcademicUnit();

        [TestMethod()]
        public void FindAll_DoesNotReturnNull()
        {
            var academicUnitDTOList = _academicUnit.FindAll();
            Assert.IsNotNull(academicUnitDTOList);
        }
    }
}