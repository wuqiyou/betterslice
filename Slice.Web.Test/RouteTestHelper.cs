using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Routing;

namespace Slice.Web.Test
{
    public static class RouteTestHelper
    {
        public static void TestRouteMatch(string url, string controller, string action)
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act - process the route
            RouteData routeData = routes.GetRouteData(CreateHttpContext(url));

            // Assert
            Assert.IsNotNull(routeData);
            Assert.AreEqual(controller, routeData.Values["controller"].ToString(), true);
            Assert.AreEqual(action, routeData.Values["action"].ToString(), true);
        }

        public static void TestRouteFail(string url)
        {
            // Arrange
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);

            // Act - process the route
            RouteData result = routes.GetRouteData(CreateHttpContext(url));
            // Assert

            Assert.IsTrue(result == null || result.Route == null);
        }

        private static HttpContextBase CreateHttpContext(string targetUrl = null)
        {
            // create the mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();
            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);

            // create the mock response
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            // create the mock context, using the request and response
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            // return the mocked context
            return mockContext.Object;
        }

    }
}
