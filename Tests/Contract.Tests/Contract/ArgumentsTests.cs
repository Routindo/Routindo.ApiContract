using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Arguments;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class ArgumentsTests
    {
        [TestMethod]
        public void CreateArgumentTest()
        {
            string key = "key";
            int value = 10;
            Argument argument = new Argument(key, value);
            Assert.AreEqual(key, argument.Key);
            Assert.AreEqual(value, argument.Value);
        }

        [TestMethod]
        public void CreateArgumentsCollectionWithOneArgumentFromConstructorTest()
        {
            string key = "key";
            int value = 10;
            ArgumentCollection argumentCollection = new ArgumentCollection((key, value));
            Assert.IsTrue(argumentCollection.Any());
            Assert.IsTrue(argumentCollection.HasArgument(key));
            Assert.AreEqual(value, argumentCollection[key]);
        }

        [TestMethod]
        public void CreateArgumentsCollectionWithOneArgumentAddedTest()
        {
            string key = "key";
            int value = 10;
            Argument argument = new Argument(key, value);
            ArgumentCollection argumentCollection = new ArgumentCollection();
            argumentCollection.Add(argument);
            Assert.IsTrue(argumentCollection.Any());
            Assert.IsTrue(argumentCollection.HasArgument(argument.Key));
            Assert.AreEqual(argument.Value, argumentCollection[argument.Key]);
        }

        [TestMethod]
        public void CreateArgumentsCollectionWithOneArgumentAttachedTest()
        {
            string key = "key";
            int value = 10;
            ArgumentCollection argumentCollection = new ArgumentCollection().WithArgument(key, value);

            Assert.IsTrue(argumentCollection.Any());
            Assert.IsTrue(argumentCollection.HasArgument(key));
            Assert.AreEqual(value, argumentCollection[key]);
        }

        [TestMethod]
        public void CreateArgumentsCollectionAsNewWithOneArgumentAttachedTest()
        {
            string key = "key";
            int value = 10;
            ArgumentCollection argumentCollection = ArgumentCollection.New().WithArgument(key, value);
            Assert.IsTrue(argumentCollection.Any());
            Assert.IsTrue(argumentCollection.HasArgument(key));
            Assert.AreEqual(value, argumentCollection[key]);
        }

        [TestMethod]
        public void CreateArgumentsCollectionFromDictionaryTest()
        {
            string key = "key";
            int value = 10;
            Dictionary<string, object> arguments = new Dictionary<string, object>()
            {
                {key, value}
            };
            ArgumentCollection argumentCollection = ArgumentCollection.FromDictionary(arguments);
            Assert.IsTrue(argumentCollection.Any());
            Assert.IsTrue(argumentCollection.HasArgument(key));
            Assert.AreEqual(value, argumentCollection[key]);
        }
    }
}
