using System;
using System.Web.Mvc;
using ControllersAndActions.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ControllersAndActions.UnitTests
{
    [TestClass]
    public class ContentFixtures
    {
        [TestMethod]
        public void ContentTest()
        {
            //Arrange - create the controller
            ReturningDataController controller = new ReturningDataController();

            //Act - call the action method
            ContentResult result = controller.Index();

            //Assert - check the result
            Assert.AreEqual("text/plain", result.ContentType);
            Assert.AreEqual("This is plain text", result.Content);
        }

        [TestMethod]
        public void FileResultTest()
        {
            //arrange - create the controller
            ReturningDataController controller = new ReturningDataController();

            //act - call the action method
            FileResult result = controller.AnnualReport();

            //Assert - check the result
            Assert.AreEqual(@"c:\AnnualReport.pdf", ((FilePathResult)result).FileName);
            Assert.AreEqual("application/pdf", result.ContentType);
            Assert.AreEqual("AnnualReport2011.pdf", result.FileDownloadName);
        }
    }
}
