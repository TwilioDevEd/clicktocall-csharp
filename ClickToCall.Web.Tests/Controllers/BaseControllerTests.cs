using System;
using System.Collections;
using System.Collections.Specialized;
using System.IO;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.WebPages;
using System.Xml;
using ClickToCall.Web.Controllers;
using ClickToCall.Web.Services;
using Moq;
using NUnit.Framework;

namespace ClickToCall.Web.Tests.Controllers
{
    public abstract class BaseControllerTests
    {
        protected MockRepository MockRepository = new Moq.MockRepository(MockBehavior.Default);

        protected Mock<ITwilioService> GetTwilioServiceMock()
        {
            var mock = MockRepository.Create<ITwilioService>();
            mock.Setup(
                s => s.CallToNumber(It.IsAny<string>(), It.IsAny<string>(),
                        It.Is<string>(uri => System.Uri.IsWellFormedUriString(uri, UriKind.Absolute))))
                .Callback(() =>
                {
                    //
                    ActionResult result = new CallController(GetTwilioRequestValidatorMock(withSuccessTwilioRequestAlways: true).Object).Connect();
                    Assert.That(result, Is.Not.Null);
                })
                .Verifiable();
            return mock;

        }

        protected Mock<ITwilioRequestValidatorService> GetTwilioRequestValidatorMock(bool withSuccessTwilioRequestAlways)
        {
            var mock = MockRepository.Create<ITwilioRequestValidatorService>();
            mock.Setup(service => service.ValidateCurrentRequest()).Returns(withSuccessTwilioRequestAlways);
            return mock;
        }


        protected ControllerContext GetControllerContextBasedOnMocks(out StringBuilder outputStream)
        {
            var result = new StringBuilder();
            var mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(s => s.Write(It.IsAny<string>())).Callback<string>(c => result.Append(c));
            mockResponse.Setup(s => s.Output).Returns(new StringWriter(result));
            //mockResponse.Setup(s => s.)

            var controllerContextMock = new Mock<ControllerContext>();
            controllerContextMock.Setup(x => x.HttpContext.Response).Returns(mockResponse.Object);

            outputStream = result;
            return controllerContextMock.Object;
        }

        protected ControllerContext GetControllerContextBasedOnMocks()
        {
            StringBuilder outputStream;
            return GetControllerContextBasedOnMocks(out outputStream);
        }

        protected XmlDocument LoadXml(string xml)
        {
            var document = new XmlDocument();
            document.LoadXml(xml);

            return document;
        }
    }
}