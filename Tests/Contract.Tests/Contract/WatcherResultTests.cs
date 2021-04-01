using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Arguments;
using Routindo.Contract.Watchers;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class WatcherResultTests
    {
        [TestMethod]
        public void CreateResultSucceedInstanceTest()
        {
            var watcherResult = WatcherResult.Succeed(ArgumentCollection.New());
            Assert.IsNotNull(watcherResult);
            Assert.IsTrue(watcherResult.Result);
        }

        [TestMethod]
        public void CreateResultFailedInstanceTest()
        {
            var watcherResult = WatcherResult.NotFound;
            Assert.IsNotNull(watcherResult);
            Assert.IsFalse(watcherResult.Result);
        }

        [TestMethod]
        public void CreateResultSucceedWithArgumentInstanceTest()
        {
            var argumentKey = "key";
            var argumentValue = "vale";
            var watcherResult = WatcherResult.Succeed(ArgumentCollection.New().WithArgument(argumentKey, argumentValue));
            Assert.IsNotNull(watcherResult);
            Assert.IsTrue(watcherResult.Result);
            Assert.IsNotNull(watcherResult.WatchingArguments);
            Assert.IsTrue(watcherResult.WatchingArguments.Any());
            Assert.AreEqual(1, watcherResult.WatchingArguments.Count);
            Assert.IsTrue(watcherResult.WatchingArguments.HasArgument(argumentKey));
            Assert.IsNotNull(watcherResult.WatchingArguments[argumentKey]);
            Assert.IsNotNull(watcherResult.WatchingArguments.GetValue<string>(argumentKey));
            Assert.AreEqual(argumentValue, watcherResult.WatchingArguments[argumentKey]);
            Assert.AreEqual(argumentValue, watcherResult.WatchingArguments.GetValue<string>(argumentKey));
        }

        [TestMethod]
        [ExpectedException(typeof(FormatException))]
        public void CreateResultSucceedWithArgumentFailsOnGettingWrongTypeTest()
        {
            var argumentKey = "key";
            var argumentValue = "vale";
            var watcherResult = WatcherResult.Succeed(ArgumentCollection.New().WithArgument(argumentKey, argumentValue));
            Assert.IsNotNull(watcherResult);
            Assert.IsTrue(watcherResult.Result);
            Assert.IsNotNull(watcherResult.WatchingArguments);
            Assert.IsTrue(watcherResult.WatchingArguments.Any());
            Assert.AreEqual(1, watcherResult.WatchingArguments.Count);
            Assert.IsTrue(watcherResult.WatchingArguments.HasArgument(argumentKey));
            watcherResult.WatchingArguments.GetValue<int>(argumentKey);
        }


    }
}
