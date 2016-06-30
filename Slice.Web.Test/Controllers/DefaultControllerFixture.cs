using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Slice.Web.Controllers;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Slice.Web.Test.Controllers
{
    [TestClass]
    public class DefaultControllerFixture
    {
        private DefaultController _controller;
        private Mock<HttpResponseBase> _mockResponse;

        [TestInitialize]
        public void Setup()
        {
            // create the mock response
            _mockResponse = new Mock<HttpResponseBase>();
            _mockResponse.Setup(m => m.AddHeader("Cache-Control", It.IsAny<string>()));
            // create the mock context, using the response
            Mock<HttpContextBase> mockHttpContext = new Mock<HttpContextBase>();
            mockHttpContext.Setup(m => m.Response).Returns(_mockResponse.Object);

            _controller = new DefaultController();
            _controller.ControllerContext = new ControllerContext(mockHttpContext.Object, new RouteData(), _controller);
        }
    }
}
