﻿using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
using SportsStore.WebUI.Controllers;
using SportsStore.WebUI.Models;

namespace SportsStore.UnitTests
{
    [TestClass]
    public class UnitTest1
    {
      

        [TestMethod]
        public void Can_Paginate()
        {
            //Arrange
            // create Mock repo
            Mock<IProductRepository> mock = new Mock<IProductRepository>();
            mock.Setup(m => m.Products).Returns(new Product[]
                                                    {
                                                        new Product {ProductID = 1, Name = "P1"},
                                                        new Product {ProductID = 2, Name = "P2"},
                                                        new Product {ProductID = 3, Name = "P3"},
                                                        new Product {ProductID = 4, Name = "P4"},
                                                        new Product {ProductID = 5, Name = "P5"}
                                                    }.AsQueryable());
            //Create a controller and make the page size 3

            ProductController controller = new ProductController(mock.Object);
            controller.PageSize = 3;

            //action

            ProductsListViewModel result = (ProductsListViewModel)controller.List(2).Model;

            //assert
            Product[] prodArray = result.Products.ToArray();
            Assert.IsTrue(prodArray.Length == 2);
            Assert.AreEqual(prodArray[0].Name, "P4");
            Assert.AreEqual(prodArray[1].Name,"P5");


        }
    }
}
