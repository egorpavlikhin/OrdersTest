using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using OrdersTest;
using OrdersTest.Controllers;
using Xunit;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace OrdersTest.Tests.Controllers
{
    public class HomeControllerTest
    {
        [Fact]
        public void Index()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.Index() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Fact]
        public void UnexpectedError()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ViewResult result = controller.UnexpectedError() as ViewResult;

            // Assert
            Assert.IsNotNull(result);
        }

        [Fact]
        public void NotFound()
        {
            // Arrange
            HomeController controller = new HomeController();

            // Act
            ActionResult result = controller.NotFound() as ActionResult;

            // Assert
            Assert.IsNotNull(result);
        }
    }
}
