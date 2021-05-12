using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Attributes;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class ArgumentInfoAttributeTests
    {
        [TestMethod]
        [TestCategory("Unit Test")]
        public void SetValuesTest()
        {
            ArgumentInfoAttribute attribute = new ArgumentInfoAttribute("Fake", true, typeof(string), "Just another fake attribute");
            Assert.AreEqual(nameof(String), attribute.Type);

            attribute = new ArgumentInfoAttribute("Fake", true, typeof(String), "Just another fake attribute");
            Assert.AreEqual(nameof(String), attribute.Type);

            attribute = new ArgumentInfoAttribute("Fake", true, typeof(long), "Just another fake attribute");
            Assert.AreEqual(nameof(Int64), attribute.Type);

            attribute = new ArgumentInfoAttribute("Fake", true, typeof(long?), "Just another fake attribute");
            Assert.AreEqual("Nullable<Int64>", attribute.Type);

            attribute = new ArgumentInfoAttribute("Fake", true, typeof(ArgumentInfoAttributeTests), "Just another fake attribute");
            Assert.AreEqual(nameof(ArgumentInfoAttributeTests), attribute.Type);

            attribute = new ArgumentInfoAttribute("Fake", true, typeof(Nullable<>), "Just another fake attribute");
            Assert.AreEqual("Nullable<T>", attribute.Type);
        }
    }
}
