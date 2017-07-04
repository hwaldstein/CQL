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
    public class SessionTests
    {
        private readonly Session _session = new Session();

        [TestMethod()]
        public void FindAll_DoesNotReturnNull()
        {
            var sessionsList = _session.FindAll();
            Assert.IsNotNull(sessionsList);
        }

        [TestMethod()]
        public void FindCurrent_DoesNotReturnNull()
        {
            var currentSession = _session.FindCurrent();
            Assert.IsNotNull(currentSession);
        }
    }
}