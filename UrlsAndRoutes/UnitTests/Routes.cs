using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Web;
using System.Web.Routing;
using UrlsAndRoutes;
using System.Reflection;
using System.Web.Mvc;

namespace UnitTests
{
    [TestClass]
    public class Routes
    {

        #region Tests
        [TestMethod]
        public void TestIncomingRoutes()
        {
            
            TestRouteMatch("~/", "Home", "Index");

            TestRouteMatch("~/Customer", "Customer", "Index");

            TestRouteMatch("~/Customer/List", "Customer", "List");

            TestRouteMatch("~/Customer/List/All", "Customer", "List", new { id = "All" });

            TestRoutingFail("~/Customer/List/All/Delete");

            TestRoutingFail("~/Customer/List/All/Delete/Perm");

            //TestRoutingFail("~/Customer/List/All/Delete");

            //TestRouteMatch("~/Shop/Index", "Home", "Index");

            ////Check for the url that we hope to receive
            //TestRouteMatch("~/Admin/Index", "Admin", "Index");

            ////Check that the values are being obtained from the segments
            //TestRouteMatch("~/One/Two", "One", "Two");

            //TestRouteMatch("~/Admin", "Admin", "Index");
            
            //TestRouteMatch("~/", "Home", "Index");

            //// ensure that too many or too few segements fails to match
            //TestRoutingFail("~/Admin/Index/Segment");
        }
        [TestMethod]
        public void TestOutgoingRoutes()
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            RequestContext context = new RequestContext(CreateHttpContext(), new RouteData());

            //Act - generate the url
            string result = UrlHelper.GenerateUrl(null, "Index", "Home", null, routes, context, true);

            //Assert
            Assert.AreEqual("/", result);
        }

        #endregion

        #region provate methods
        private void TestRouteMatch(string url, string controller, string action, object routeProperties = null, string httpMethod = "Get")
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            //Act - process the route

            RouteData result = routes.GetRouteData(CreateHttpContext(url, httpMethod));

            //Assert
            Assert.IsNotNull(result);
            Assert.IsTrue(TestIncomingRouteResult(result, controller, action, routeProperties));
        }

        private void TestRoutingFail(string url)
        {
            //Arrange
            RouteCollection routes = new RouteCollection();
            MvcApplication.RegisterRoutes(routes);

            //Act - process the route

            RouteData result = routes.GetRouteData(CreateHttpContext(url));

            //Assert
            Assert.IsTrue(result == null || result.Route == null);
        }
        #endregion

        #region helper methods

        /// <summary>
        /// Helper methods for testing url routing
        /// </summary>
        /// <param name="targetUrl"></param>
        /// <param name="httpMethod"></param>
        /// <returns>Mock HttpContext Base</returns>
        private HttpContextBase CreateHttpContext(string targetUrl = null, string httpMethod = "GET")
        {
            //create the Mock request
            Mock<HttpRequestBase> mockRequest = new Mock<HttpRequestBase>();

            mockRequest.Setup(m => m.AppRelativeCurrentExecutionFilePath).Returns(targetUrl);
            mockRequest.Setup(m => m.HttpMethod).Returns(httpMethod);

            // create Mock Respsonse
            Mock<HttpResponseBase> mockResponse = new Mock<HttpResponseBase>();
            mockResponse.Setup(m => m.ApplyAppPathModifier(It.IsAny<string>())).Returns<string>(s => s);

            //create mock context
            Mock<HttpContextBase> mockContext = new Mock<HttpContextBase>();
            mockContext.Setup(m => m.Request).Returns(mockRequest.Object);
            mockContext.Setup(m => m.Response).Returns(mockResponse.Object);

            //return the mocked context

            return mockContext.Object;

        }


        private bool TestIncomingRouteResult(RouteData routeResult, string controller, string action, object routeProperties = null)
        {
            Func<object, object, bool> valCompare = (v1, v2) => { return StringComparer.InvariantCultureIgnoreCase.Compare(v1, v2) == 0; };

            bool result = valCompare(routeResult.Values["controller"], controller) && valCompare(routeResult.Values["action"], action);

            if (routeProperties != null)
            {
                PropertyInfo[] propInfo = routeProperties.GetType().GetProperties();
                foreach (PropertyInfo pi in propInfo)
                {
                    if (!(routeResult.Values.ContainsKey(pi.Name) && valCompare(routeResult.Values[pi.Name], pi.GetValue(routeProperties, null))))
                    {
                        result = false;
                        break;
                    }
                }
            }

            return result;

        }

       
        #endregion
    }
}
