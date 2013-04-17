using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class AdminControllerFixture
    {

        [TestMethod]
        public void Can_Delete_Valid_Products()
        {
            //Arrange - create a product
            Product prod = new Product {ProductID = 2, Name = "Test"};

            // Arrange - Create mock repo

            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new Product[]
                    {new Product {ProductID = 1, Name = "P1"}, prod, new Product {ProductID = 3, Name = "P3"}}
                        .AsQueryable());

            //Arrange - create controller
            AdminController target = new AdminController(mock.Object);

            //Act - delete the product
            target.Delete(prod.ProductID);

            //Assert - ensure that the repository delete mthod was called with correct product
            mock.Verify(m=>m.DeleteProduct(prod));

        }

        [TestMethod]
        public void Cannot_Delete_Invalid_Products()
        {
            // Arrange - create mock repository
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products)
                .Returns(
                    new Product[]
                    {
                        new Product {ProductID = 1, Name = "P1"}, 
                        new Product {ProductID = 2, Name = "P2"},
                        new Product {ProductID = 3, Name = "P3"}
                    }.AsQueryable());

            //Arrange - create the controller

            AdminController target = new AdminController(mock.Object);

            //Act - delete using

            target.Delete(100);

            //Assert - ensure that the reposity delete method was not called due to invalid product
            mock.Verify(m=>m.DeleteProduct(It.IsAny<Product>()),Times.Never());

        }
    }
}
