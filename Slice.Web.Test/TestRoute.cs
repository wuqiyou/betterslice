using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Slice.Web.Test
{
    [TestClass]
    public class TestRoute
    {
        [TestMethod]
        public void TestIncomingRoutes()
        {
            RouteTestHelper.TestRouteMatch("~/home", "default", "index");
        }
    }
}
