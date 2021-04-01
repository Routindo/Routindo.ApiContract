using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Plugin;
using Routindo.Contract.Tests.Mock;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class ComponentsInfoTests
    {
        [TestMethod]
        public void CreateActionInfoTest()
        {
            var id = PluginUtilities.GetUniqueId();
            string name = "actionName";
            string description = "This is action description";
            var actionInstance = RoutindoActionInfo.Create<ActionMock>(id, name, description);
            Assert.IsNotNull(actionInstance);
            Assert.AreEqual(id, actionInstance.Id);
            Assert.AreEqual(name, actionInstance.Name);
            Assert.AreEqual(description, actionInstance.Description);
            Assert.AreEqual(typeof(ActionMock), actionInstance.ComponentType);
        }

        [TestMethod]
        public void CreateWatcherInfoTest()
        {
            var id = PluginUtilities.GetUniqueId();
            string name = "watcherName";
            string description = "This is watcher description";
            var watcherInstance = RoutindoWatcherInfo.Create<WatcherMock>(id, name, description);
            Assert.IsNotNull(watcherInstance);
            Assert.AreEqual(id, watcherInstance.Id);
            Assert.AreEqual(name, watcherInstance.Name);
            Assert.AreEqual(description, watcherInstance.Description);
            Assert.AreEqual(typeof(WatcherMock), watcherInstance.ComponentType);
        }

        [TestMethod]
        public void CreateArgumentMapperInfoTest()
        {
            var id = PluginUtilities.GetUniqueId();
            string name = "ComponentName";
            string description = "This is Component description";
            var componentInstance = RoutindoArgumentsMapperInfo.Create<ArgumentMapperMock>(id, name, description);
            Assert.IsNotNull(componentInstance);
            Assert.AreEqual(id, componentInstance.Id);
            Assert.AreEqual(name, componentInstance.Name);
            Assert.AreEqual(description, componentInstance.Description);
            Assert.AreEqual(typeof(ArgumentMapperMock), componentInstance.ComponentType);
        }

    }
}
