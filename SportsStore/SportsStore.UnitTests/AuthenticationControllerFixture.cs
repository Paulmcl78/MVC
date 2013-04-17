﻿using System;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Infrastructure.Abstract;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AuthenticationControllerFixture
    {
        [TestMethod]
        public void Can_Login_With_Valid_Creditals()
        {
            //Arrange - create a mock authentication provider
            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("admin", "secret")).Returns(true);

            //Arrange - create the view model

            LogOnViewModel model = new LogOnViewModel
            {
                UserName = "admin",
                Password = "secret"
            };

            //Arrange - create the controller
            AccountController controller = new AccountController(mock.Object);

            //Act - authenticate using valid credentials
            ActionResult result = controller.LogOn(model, "/MyUrl");

            //Assert
            Assert.IsInstanceOfType(result, typeof(RedirectResult));
            Assert.AreEqual("/MyUrl",((RedirectResult)result).Url);
        }

        [TestMethod]
        public void Cannot_Login_With_Invalid_Credentials()
        {
            //Arrange - create a mock Authentication provider

            Mock<IAuthProvider> mock = new Mock<IAuthProvider>();
            mock.Setup(m => m.Authenticate("badUser", "badPassword")).Returns(false);

            //arrange - create the view model
            LogOnViewModel model = new LogOnViewModel
            {
                UserName = "badUser",
                Password = "badPassword"
            };

            //Arrange - create the controller
            AccountController controller = new AccountController(mock.Object);

            //Act - authenticate using invalid credentials
            ActionResult result = controller.LogOn(model, "/MyUrl");

            //Assert
            Assert.IsInstanceOfType(result,typeof(ViewResult));
            Assert.IsFalse(((ViewResult)result).ViewData.ModelState.IsValid);

        }
    }
}