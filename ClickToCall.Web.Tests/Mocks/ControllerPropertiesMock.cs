using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Moq;

namespace ClickToCall.Web.Tests.Mocks
{
    public class ControllerPropertiesMock
    {
        private readonly Mock<ControllerContext> _controllerContext;

        public ControllerPropertiesMock()
        {
            var mockRequest = new Mock<HttpRequestBase>();
            mockRequest.SetupGet(r => r.Url).Returns(new Uri("http://www.example.com"));

            var mockResponse = Mock.Of<HttpResponseBase>();

            _controllerContext = new Mock<ControllerContext>();
            _controllerContext.Setup(x => x.HttpContext.Request).Returns(mockRequest.Object);
            _controllerContext.Setup(x => x.HttpContext.Response).Returns(mockResponse);
        }

        public ControllerContext ControllerContext => _controllerContext.Object;

        public UrlHelper Url => new UrlHelper(
            new RequestContext(_controllerContext.Object.HttpContext, new RouteData()),
            new RouteCollection());
    }
}
