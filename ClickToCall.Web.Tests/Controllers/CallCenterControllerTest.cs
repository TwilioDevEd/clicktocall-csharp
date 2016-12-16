using ClickToCall.Web.Controllers;
using ClickToCall.Web.Services;
using ClickToCall.Web.Models;
using ClickToCall.Web.Tests.Mocks;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ClickToCall.Web.Tests.Controllers
{
    [TestFixture]
    public class CallCenterControllerTest
    {
        [Test]
        public void ShouldStartCallWithRealNumber()
        {
            var mockNotificationService = new Mock<INotificationService>();
            var mockControllerProperties = new ControllerPropertiesMock();
            var controller = new CallCenterController(mockNotificationService.Object)
                {
                    ControllerContext = mockControllerProperties.ControllerContext,
                    Url = mockControllerProperties.Url
                };

            controller
                .WithCallTo(c => c.Call(new Contact { Phone = "1234567890" }))
                .ShouldReturnJson(data =>
                    {
                        Assert.That(data.message, Is.EqualTo("Phone call incoming!"));
                    });

            mockNotificationService.Verify(
                s => s.MakePhoneCall("twilio-number", "1234567890", "http://test.domain.com"), Times.Once());
        }
    }
}
