using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Tests.Mock;

namespace Routindo.Contract.Tests.Contract.UI
{
    [TestClass]
    public class PluginConfiguratorTests
    {
        #region Validation 
        [TestMethod]
        public void ValidateEmailPropertyTest()
        {
            var mock = new PluginConfiguratorMock();
            mock.EmailProperty = "Sample String";
            Assert.IsTrue(mock.HasErrors);
            Assert.IsFalse(mock.CanConfigure());
            var errorsList = mock.GetErrors(nameof(mock.EmailProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "Email must be in format 'username@domain.extension'";
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.EmailProperty = "name@domain.com";
            Assert.IsFalse(mock.HasErrors);
            Assert.IsTrue(mock.CanConfigure());
        }

        [TestMethod]
        public void ValidateNumberPropertyTest()
        {
            var mock = new PluginConfiguratorMock();
            mock.NumberProperty = 1;
            Assert.IsFalse(mock.HasErrors);
        }

        [TestMethod]
        public void ValidateNegativeNumberPropertyTest()
        {
            var mock = new PluginConfiguratorMock();
            mock.NegativeNumberProperty = 32;
            Assert.IsTrue(mock.HasErrors);
            var errorsList = mock.GetErrors(nameof(mock.NegativeNumberProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "Please enter a correct value.";
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.NegativeNumberProperty = -1;
            Assert.IsFalse(mock.HasErrors);
        }

        [TestMethod]
        public void ValidatePositiveNumberPropertyTest()
        {
            var mock = new PluginConfiguratorMock();
            // Zero Value
            mock.PositiveNumberProperty = 0;
            Assert.IsTrue(mock.HasErrors);

            // Negative Value
            mock.PositiveNumberProperty = -1;
            Assert.IsTrue(mock.HasErrors);

            var errorsList = mock.GetErrors(nameof(mock.PositiveNumberProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "Please enter a correct value.";
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.PositiveNumberProperty = 1;
            Assert.IsFalse(mock.HasErrors);
        }

        [TestMethod]
        public void ValidateZeroNumberPropertyTest()
        {
            var mock = new PluginConfiguratorMock();
            // Zero Value
            mock.ZeroNumberProperty = 1;
            Assert.IsTrue(mock.HasErrors);

            // Negative Value
            mock.ZeroNumberProperty = -1;
            Assert.IsTrue(mock.HasErrors);

            var errorsList = mock.GetErrors(nameof(mock.ZeroNumberProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "Please enter a correct value.";
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.ZeroNumberProperty = 0;
            Assert.IsFalse(mock.HasErrors);
        }

        [TestMethod]
        public void ValidateNonClearedErrorsPositivePropertyTest() 
        {
            var mock = new PluginConfiguratorMock();
            // Zero Value
            mock.NonClearedErrorsPositiveProperty = 0;
            Assert.IsTrue(mock.HasErrors);

            // Negative Value
            mock.NonClearedErrorsPositiveProperty = -1;
            Assert.IsTrue(mock.HasErrors);

            var errorsList = mock.GetErrors(nameof(mock.NonClearedErrorsPositiveProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "Please enter a correct value.";
            
            // Only one error 
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.NonClearedErrorsPositiveProperty = 1;
            Assert.IsTrue(mock.HasErrors);

            errorsList = mock.GetErrors(nameof(mock.NonClearedErrorsPositiveProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
        }

        [TestMethod]
        public void ValidateNonNullOrEmptyStringTest()
        {
            var mock = new PluginConfiguratorMock();
            // Zero Value
            mock.NonNullOrEmptyStringProperty = null;
            Assert.IsTrue(mock.HasErrors);

            // Negative Value
            mock.NonNullOrEmptyStringProperty = "";
            Assert.IsTrue(mock.HasErrors);

            var errorsList = mock.GetErrors(nameof(mock.NonNullOrEmptyStringProperty)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "This field cannot be empty";
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.NonNullOrEmptyStringProperty = "Hello world!";
            Assert.IsFalse(mock.HasErrors);
        }

        [TestMethod]
        public void ValidatePortNumberTest()
        {
            var mock = new PluginConfiguratorMock();
            // Zero Value
            mock.PortNumber = 0;
            Assert.IsTrue(mock.HasErrors);

            // Negative Value
            mock.PortNumber = -15;
            Assert.IsTrue(mock.HasErrors);

            // more than Maximum Value
            mock.PortNumber = 65535 + 1;
            Assert.IsTrue(mock.HasErrors);

            var errorsList = mock.GetErrors(nameof(mock.PortNumber)).OfType<string>().ToList();
            Assert.IsNotNull(errorsList);
            Assert.AreEqual(1, errorsList.Count);
            var expectedError = "Please entry a correct port number";
            Assert.AreEqual(expectedError, errorsList.Single());
            mock.PortNumber = 21;
            Assert.IsFalse(mock.HasErrors);

            // Maximum Value
            mock.PortNumber = 65535;
            Assert.IsFalse(mock.HasErrors);
        }

        #endregion 


    }
}
