using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Helpers;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class ObjectExtensionsTests
    {
        [TestMethod]
        public void CheckIfNullableTest()
        {
            int? nullableNumber = null;
            int nonNullableNumber = 1;

            Assert.IsTrue(nullableNumber.IsNullable<int>());
            Assert.IsFalse(nonNullableNumber.IsNullable<int>());
        }
    }
}
