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
    }
}
