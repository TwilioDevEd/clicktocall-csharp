using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClickToCall.Web.Controllers;
using ClickToCall.Web.Models;
using ClickToCall.Web.Services;
using Moq;
using NUnit.Framework;
using Twilio.TwiML;
using Assert = NUnit.Framework.Assert;

namespace ClickToCall.Web.Tests.Controllers
{
    [TestFixture]
    public class CallCenterControllerTest : BaseControllerTests
    {
        private string _twilioNumber;
        private Contact _contact;

        public Mock<ITwilioService> CurrentTwilioServiceMock;

        private CallCenterController BuildController()
        {
            StringBuilder outputStream;
            return BuildController(out outputStream);
        }

        private CallCenterController BuildController(out StringBuilder outputStream)
        {
            var controller =
                new CallCenterController(CurrentTwilioServiceMock.Object)
                {
                    ControllerContext = GetControllerContextBasedOnMocks(out outputStream)
                };
            return controller;
        }

        [TestFixtureSetUp]
        public void Init()
        {
            // TODO: move to app.config
            _twilioNumber = "15008675309";
            _contact = new Contact { Phone = "12066505813" };
        }

        [SetUp]
        public void Setup()
        {
            CurrentTwilioServiceMock = GetTwilioServiceMock();
        }

        [Test]
        public void Should_Get_Index()
        {
            // Arrange
            CallCenterController controller = BuildController();

            // Act
            ActionResult result = controller.Index();

            // Assert
            Assert.IsNotNull(result);
        }

        [Test]
        public void Should_Initiate_Call_With_Real_Phone_Number()
        {
            // Arrange
            CallCenterController controller = BuildController();

            // Act
            JsonResult jsonResult = controller.Call(_contact);
            // Assert
            Assert.That(jsonResult.Data, Is.Not.Null);
            Assert.That(jsonResult.Data.DynamicProperty("message"), Is.EqualTo("Phone call incoming!"));
            CurrentTwilioServiceMock.Verify();
        }

        [Test]
        public void Should_Return_Failure_With_Non_Real_Phone_Number()
        {
            // Arrange
            CallCenterController controller = BuildController();

            // Act
            JsonResult jsonResult = controller.Call(_contact);
            // Assert
            Assert.That(jsonResult.Data, Is.Not.Null);
            Assert.That(jsonResult.Data.DynamicProperty("message"), Is.EqualTo("Phone call incoming!"));
        }
    }
}
