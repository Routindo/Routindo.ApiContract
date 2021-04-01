using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Routindo.Contract.Services;
using Routindo.Contract.Tests.Mock;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class ServiceContainerTests
    {
        [TestMethod]
        public void GetSampleInstanceOfServiceContainerTest()
        {
            Assert.IsNull(ServicesContainer.ServicesProvider);
            ServicesContainer.SetServicesProvider(new ServicesProviderMock());
            Assert.IsNotNull(ServicesContainer.ServicesProvider);
        }

        [TestMethod]
        public void GetServicesTest()
        {
            Assert.IsNull(ServicesContainer.ServicesProvider);

            var servicesProviderMock = new Mock<IServicesProvider>();
            servicesProviderMock.Setup(provider => provider.GetEnvironmentService())
                .Returns(new EnvironmentServiceMock());
            servicesProviderMock.Setup(provider => provider.GetLoggingService(It.IsAny<string>(), null))
                .Returns(new LoggingServiceMock());

            IServicesProvider servicesProvider = servicesProviderMock.Object;
            ServicesContainer.SetServicesProvider(servicesProvider);
            Assert.IsNotNull(ServicesContainer.ServicesProvider);

            Assert.IsNotNull(servicesProvider.GetLoggingService("any"));
            Assert.IsNotNull(servicesProvider.GetEnvironmentService());
        }
    }
}
