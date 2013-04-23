using System;
using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.UnitTests
{
    [TestClass]
    public class HttpStatusCodeFixures
    {
        [TestMethod]
        public void StatusCodeTest()
        {
            //Arrange - create the controller
            ErrorsAndHttpCodesController controller = new ErrorsAndHttpCodesController();

            //Act - call the action method
            HttpStatusCodeResult result = controller.StatusCode();

            //Assert - Check the result
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void notFoundTest()
        {
            //Arrange - create the controller
            ErrorsAndHttpCodesController controller = new ErrorsAndHttpCodesController();

            //Act - call the action method
            HttpStatusCodeResult result = controller.notFound();

            //Assert - Check the result
            Assert.AreEqual(404, result.StatusCode);
        }

        [TestMethod]
        public void NotAuthorizedTest()
        {

            //Arrange - create the controller
            ErrorsAndHttpCodesController controller = new ErrorsAndHttpCodesController();

            //Act - call the action method
            HttpStatusCodeResult result = controller.NotAuthorized();

            //Assert - Check the result
            Assert.AreEqual(401, result.StatusCode);
        }

    }
}
