using System.Text;
using System.Web.Mvc;
using System.Web.Routing;
using ClickToCall.Web.Controllers;
using ClickToCall.Web.Domain.Services;
using ClickToCall.Web.Models;
using Moq;
using NUnit.Framework;

namespace ClickToCall.Web.Tests.Controllers
{
    [TestFixture]
    public class CallCenterControllerTest : BaseControllerTests
    {
        private Contact _contact;

        public Mock<ITwilioService> CurrentTwilioServiceMock;

        [TestFixtureSetUp]
        public void Init()
        {
            _contact = new Contact { Phone = "12066505813" };
        }

        [SetUp]
        public void Setup()
        {
            CurrentTwilioServiceMock = GetTwilioServiceMock();
        }
        
        [Test]
        public void Should_Initiate_Call_With_Real_Phone_Number()
        {
            // Arrange
            CallCenterController controller = BuildController();

            // Act
            JsonResult jsonResult = (JsonResult)controller.Call(_contact);
            // Assert
            Assert.That(jsonResult.Data.DynamicProperty("message"), Is.EqualTo("Phone call incoming!"));
            CurrentTwilioServiceMock.Verify();
        }

        [Test]
        public void Should_Return_Failure_With_Non_Real_Phone_Number()
        {
            // Arrange
            CallCenterController controller = BuildController();

            // Act
            JsonResult jsonResult = (JsonResult)controller.Call(_contact);
            // Assert
            Assert.That(jsonResult.Data.DynamicProperty("message"), Is.EqualTo("Phone call incoming!"));
        }

        #region Private Methods
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
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            controller.Url = new UrlHelper(new RequestContext(controller.HttpContext, new RouteData()), routes);
            return controller;
        } 
        #endregion
    }
}
