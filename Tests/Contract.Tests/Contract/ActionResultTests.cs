using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Routindo.Contract.Actions;
using Routindo.Contract.Arguments;

namespace Routindo.Contract.Tests.Contract
{
    [TestClass]
    public class ActionResultTests
    {
        [TestMethod]
        [Description("Create a sample action result with result succeeded")]
        public void CreateSucceededActionResultTest()
        {
            ActionResult actionResult = ActionResult.Succeeded();
            Assert.IsTrue(actionResult.Result);
        }

        [TestMethod]
        [Description("Create a sample action result with result failed")]
        public void CreateFailedActionResultTest()
        {
            ActionResult actionResult = ActionResult.Failed();
            Assert.IsFalse(actionResult.Result);
        }

        [TestMethod]
        [Description("Create a sample action result with result failed and attached exception")]
        public void CreateFailedActionResultWithExceptionTest()
        {
            string exceptionMessage = "This is an exception";
            ActionResult actionResult = ActionResult.Failed().WithException(new Exception(exceptionMessage));
            Assert.IsFalse(actionResult.Result);
            Assert.IsNotNull(actionResult.AttachedException);
            Assert.AreEqual(exceptionMessage, actionResult.AttachedException.Message);
        }

        [TestMethod]
        [Description("Create a sample action result with result succeeded with additional information")]
        public void CreateSucceededActionResultWithAdditionalInformationTest()
        {
            string additionalInformationKey = "AdditionalInformation";
            string additionalInformationValue = "AdditionalInformationValue";
            ArgumentCollection additionInformation = new ArgumentCollection((additionalInformationKey, additionalInformationValue));
            ActionResult actionResult = ActionResult.Succeeded().WithAdditionInformation(additionInformation);
            Assert.IsTrue(actionResult.Result);
            Assert.IsNotNull(actionResult.AdditionalInformation);
            Assert.IsTrue(actionResult.AdditionalInformation.Any());
            Assert.IsTrue(actionResult.AdditionalInformation.HasArgument(additionalInformationKey));
            Assert.AreEqual(actionResult.AdditionalInformation.GetValue<string>(additionalInformationKey), additionalInformationValue);
        }

        [TestMethod]
        [Description("Create a sample action result with result succeeded then add additional information")]
        public void CreateSucceededActionResultAndAddAdditionalInformationTest()
        {
            string additionalInformationKey = "AdditionalInformation";
            string additionalInformationValue = "AdditionalInformationValue";
            ArgumentCollection additionInformation = new ArgumentCollection((additionalInformationKey, additionalInformationValue));
            ActionResult actionResult = ActionResult.Succeeded();
            Argument argument = new Argument(additionalInformationKey, additionalInformationValue);
            actionResult.AdditionalInformation.Add(argument);
            Assert.IsTrue(actionResult.Result);
            Assert.IsNotNull(actionResult.AdditionalInformation);
            Assert.IsTrue(actionResult.AdditionalInformation.Any());
            Assert.IsTrue(actionResult.AdditionalInformation.HasArgument(additionalInformationKey));
            Assert.AreEqual(actionResult.AdditionalInformation.GetValue<string>(additionalInformationKey), additionalInformationValue);
        }

        [TestMethod]
        [Description("Create a sample action result with result failed and Attached Exception with Additional Information")]
        public void CreateFailedActionResultWithExceptionAndAdditionalInformationTest()
        {
            string additionalInformationKey = "AdditionalInformation";
            string additionalInformationValue = "AdditionalInformationValue";
            string exceptionMessage = "This is an exception";

            ArgumentCollection additionInformation = new ArgumentCollection((additionalInformationKey, additionalInformationValue));
            ActionResult actionResult = ActionResult.Failed().WithException(new Exception(exceptionMessage)).WithAdditionInformation(additionInformation);
            Assert.IsFalse(actionResult.Result);

            // Assert Additional Information
            Assert.IsNotNull(actionResult.AdditionalInformation);
            Assert.IsTrue(actionResult.AdditionalInformation.Any());
            Assert.IsTrue(actionResult.AdditionalInformation.HasArgument(additionalInformationKey));
            Assert.AreEqual(actionResult.AdditionalInformation.GetValue<string>(additionalInformationKey), additionalInformationValue);

            // Assert Attached Exception
            Assert.IsNotNull(actionResult.AttachedException);
            Assert.AreEqual(exceptionMessage, actionResult.AttachedException.Message);
        }
    }
}
