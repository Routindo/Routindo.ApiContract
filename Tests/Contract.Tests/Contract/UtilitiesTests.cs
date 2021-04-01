using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class UtilitiesTests
    {
        [TestMethod]
        public void GetUniqueIdTest()
        {
            var uniqueId = PluginUtilities.GetUniqueId();
            var upperCaseUniqueId = uniqueId.ToUpper();
            Assert.IsFalse(string.IsNullOrWhiteSpace(uniqueId));
            // Assert unique Id is generated in upper cases
            Assert.AreEqual(uniqueId, upperCaseUniqueId);
        }
    }
}
