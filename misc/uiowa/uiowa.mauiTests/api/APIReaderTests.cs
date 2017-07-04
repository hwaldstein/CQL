using Microsoft.VisualStudio.TestTools.UnitTesting;
using uiowa.maui.api;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using uiowa.maui.api.dto.documentation;

namespace uiowa.maui.api.Tests
{
    [TestClass()]
    public class APIReaderTests
    {
        private readonly APIReader _reader = new APIReader();

        [TestMethod()]
        public void GetAllDocumentation_DoesNotReturnNull()
        {
            var documentation = _reader.GetAllDocumentation();

            Assert.IsNotNull(documentation);
        }

        [TestMethod()]
        public void GetApiForApiPath_DoesNotReturnNull()
        {
            var api = _reader.GetApiForApiPath("/pub/documentation");
            Assert.IsNotNull(api);
        }

        [TestMethod()]
        public void GetApiForOperationPath_DoesNotReturnNull()
        {
            var resource = _reader.GetApiForOperationPath("/pub/documentation/all");
            Assert.IsNotNull(resource);
        }
    }
}