using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Helpers;
using Routindo.Contract.Tests.Mock;

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

        [TestMethod]
        public void SampleObjectSerializationTest()
        {
            ChildSerializationObjectMock childObj = new ChildSerializationObjectMock()
            {
                IntegerProperty = 10,
                StringProperty = "This is an String Property!"
            };

            var expectedResult = $"{{\"StringProperty\":\"{childObj.StringProperty}\",\"IntegerProperty\":{childObj.IntegerProperty}}}";
            var serializationResult = childObj.ToJsonString(false);
            Console.WriteLine(serializationResult);
            Assert.AreEqual(expectedResult, serializationResult);
        }

        [TestMethod]
        [Description("Serialization with composed object")]
        public void ObjectSerializationTest()
        {
            SerializationObjectMock parentObj = new SerializationObjectMock()
            {
                IntegerProperty = 5,
                StringProperty = "This is a parent String Property!",
                ChildProperty = new ChildSerializationObjectMock()
                {
                    IntegerProperty = 10,
                    StringProperty = "This is an String Property!"
                }
            };

            var expectedChildResult = $"{{\"StringProperty\":\"{parentObj.ChildProperty.StringProperty}\",\"IntegerProperty\":{parentObj.ChildProperty.IntegerProperty}}}";
            var childSerializationResult = parentObj.ChildProperty.ToJsonString(false);
            Console.WriteLine(childSerializationResult);
            Assert.AreEqual(expectedChildResult, childSerializationResult);

            var expectedResult =
                $"{{\"StringProperty\":\"{parentObj.StringProperty}\",\"IntegerProperty\":{parentObj.IntegerProperty},\"ChildProperty\":{{\"StringProperty\":\"{parentObj.ChildProperty.StringProperty}\",\"IntegerProperty\":{parentObj.ChildProperty.IntegerProperty}}}}}";
            var serializationResult = parentObj.ToJsonString(false);
            Console.WriteLine(serializationResult);
            Assert.AreEqual(expectedResult, serializationResult);
        }

        [TestMethod]
        [Description("Serialization result is string 'null' ")]
        public void ObjectSerializationFailsOnNullObjectTest()
        {
            ChildSerializationObjectMock childObj = GetNullSerializationObject();
            var serializationResult = childObj.ToJsonString(false);
            Assert.AreEqual("null", serializationResult);
        }

        private ChildSerializationObjectMock GetNullSerializationObject()
        {
            return null;
        }
    }
}
