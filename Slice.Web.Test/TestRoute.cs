using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Slice.Web.Test
{
    [TestClass]
    public class TestRoute
    {
        [TestMethod]
        public void TestIncomingRoutes()
        {
            string t = null; 

            if (object.Equals(t, "true"))
            {

            }

            if (t == "true")
            {
                t = "false";
            }

            //RouteTestHelper.TestRouteMatch("~/home", "default", "index");
        }
    }
}
