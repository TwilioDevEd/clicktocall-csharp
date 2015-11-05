using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.InteropServices;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClickToCall.Web.Controllers;
using ClickToCall.Web.Models;
using Moq;
using NUnit.Framework;
using Twilio.TwiML;
using Assert = NUnit.Framework.Assert;

namespace ClickToCall.Web.Tests.Controllers
{
    [TestFixture]
    public class CallControllerTests : BaseControllerTests
    {
        [TestFixtureSetUp]
        public void Init()
        {
        }

        private CallController BuildController(bool succesRequestValidatorShouldReturnAlways)
        {
            StringBuilder outputStream;
            return BuildController(succesRequestValidatorShouldReturnAlways, out outputStream);
        }

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
            Assert.That(result, Is.Not.Null);
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

            Assert.That(result, Is.Not.Null);
            Assert.That(twilioResponse.SelectNodes("Response/Say").Count, Is.EqualTo(1));
            Assert.That(twilioResponse.SelectSingleNode("Response/Hangup"), Is.Not.Null);
        }
    }
}
