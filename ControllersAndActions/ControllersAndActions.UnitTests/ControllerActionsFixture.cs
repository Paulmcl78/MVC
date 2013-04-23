using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.UnitTests
{
    [TestClass]
    public class ControllerActionsFixture
    {
        [TestMethod]
        public void ViewSelectionTest()
        {
            //arrange - create the controller
            DerivedController controller = new DerivedController();

            //Act - call the action menthod
            ViewResult result = controller.ForTest();

            //Assert
            Assert.AreEqual("Homepage", result.ViewName);

        }

        [TestMethod]
        public void ViewSelectionTestWithObject()
        {
            //Arrange - create the controller
            ExampleController controller = new ExampleController();

            //Act -  call the action method
            ViewResult result = controller.forTest();

            //assert - check the result
            Assert.AreEqual("Hello, world", result.ViewData.Model);

        }

        [TestMethod]
        public void TestViewBag()
        {
            //Arrange - create the controller
            ExampleController controller = new ExampleController();

            //Act - call the action method
            ViewResult result = controller.ViewBagTest();

            //Assert -  check the result
            Assert.AreEqual("Hello", result.ViewBag.Message);

        }

        [TestMethod]
        public void LiteralRedirectTest()
        {
            //Arrange - create the controller
            RedirectController controller = new RedirectController();

            //Act - call the action method
            RedirectResult result = controller.Redirect();

            //Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("/Example/Index", result.Url);

        }

        [TestMethod]
        public void RedirectToRouteTest()
        {
            //Arrange - create the controller
            RedirectController controller = new RedirectController();

            //Act -call the action method
            RedirectToRouteResult result = controller.RedirectToRoute();

            //Assert - check the result
            Assert.IsFalse(result.Permanent);
            Assert.AreEqual("Example", result.RouteValues["controller"]);
            Assert.AreEqual("Index", result.RouteValues["action"]);
            Assert.AreEqual("MyId", result.RouteValues["ID"]);
        }
    }
}
