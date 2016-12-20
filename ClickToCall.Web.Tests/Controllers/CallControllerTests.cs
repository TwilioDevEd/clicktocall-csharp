using System.Net;
using System.Web;
using System.Xml.XPath;
using ClickToCall.Web.Controllers;
using ClickToCall.Web.Services;
using ClickToCall.Web.Tests.Extensions;
using Moq;
using NUnit.Framework;
using TestStack.FluentMVCTesting;

namespace ClickToCall.Web.Tests.Controllers
{
    [TestFixture]
    public class CallControllerTests
    {
        private Mock<IRequestValidationService> _mockValidatorService;

        [SetUp]
        public void Init()
        {
            _mockValidatorService = new Mock<IRequestValidationService>();
        }

        [Test]
        public void ShouldRespondUnauthorizedOnInvalidRequest()
        {
            _mockValidatorService
                .Setup(service => service.IsValidRequest(It.IsAny<HttpContext>(), It.IsAny<string>()))
                .Returns(false);

            var controller = new CallController(_mockValidatorService.Object);
            controller
                .WithCallTo(c => c.Connect("sales-number"))
                .ShouldGiveHttpStatus(HttpStatusCode.Unauthorized);
        }

        [Test]
        public void ShouldRespondWithTwiMLOnValidRequest()
        {
            _mockValidatorService
                .Setup(service => service.IsValidRequest(It.IsAny<HttpContext>(), It.IsAny<string>()))
                .Returns(true);

            var controller = new CallController(_mockValidatorService.Object);
            controller
                .WithCallTo(c => c.Connect("sales-number"))
                .ShouldReturnTwiMLResult(data =>
                {
                    StringAssert.Contains(
                        "Thanks for contacting", data.XPathSelectElement("Response/Say").Value);
                    Assert.That(data.XPathSelectElement("Response/Dial").Value, Is.EqualTo("sales-number"));
                });
        }
    }
}

