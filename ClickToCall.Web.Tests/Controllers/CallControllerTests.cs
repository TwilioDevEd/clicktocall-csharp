using System.Net;
using System.Text;
using System.Web.Mvc;
using ClickToCall.Web.Controllers;
using NUnit.Framework;

namespace ClickToCall.Web.Tests.Controllers
{
    [TestFixture]
    public class CallControllerTests : BaseControllerTests
    {
        private CallController BuildController(bool succesRequestValidatorShouldReturnAlways, out StringBuilder outputStream)
        {
            var controller =
                new CallController(succesRequestValidatorShouldReturnAlways
                    ? GetTwilioRequestValidatorMock(withSuccessTwilioRequestAlways: true).Object
                    : GetTwilioRequestValidatorMock(withSuccessTwilioRequestAlways: false).Object)
                {
                    ControllerContext = GetControllerContextBasedOnMocks(out outputStream)
                };
            return controller;
        }

        [Test]
        public void Should_Fail_As_Fake_Twilio_Request()
        {
            // Arrange
            CallController controller = BuildController(succesRequestValidatorShouldReturnAlways: false);

            // Act
            ActionResult result = controller.Connect();
            result.ExecuteResult(controller.ControllerContext);

            // Assert
            Assert.That(((HttpStatusCodeResult) result).StatusCode, Is.EqualTo((int)HttpStatusCode.Unauthorized));
        }

        [Test]
        public void Should_Succeed_With_Real_Twilio_request()
        {
            // Arrange
            StringBuilder outputStream;
            CallController controller = BuildController(succesRequestValidatorShouldReturnAlways: true, outputStream: out outputStream);

            // Act
            ActionResult result = controller.Connect();
            result.ExecuteResult(controller.ControllerContext);

            // Assert
            var twilioResponse = LoadXml(outputStream.ToString());

            Assert.That(twilioResponse.SelectNodes("Response/Say").Count, Is.EqualTo(1));
            Assert.That(twilioResponse.SelectSingleNode("Response/Hangup"), Is.Not.Null);
        }

        #region Private Methods
        private CallController BuildController(bool succesRequestValidatorShouldReturnAlways)
        {
            StringBuilder outputStream;
            return BuildController(succesRequestValidatorShouldReturnAlways, out outputStream);
        } 
        #endregion
    }
}
