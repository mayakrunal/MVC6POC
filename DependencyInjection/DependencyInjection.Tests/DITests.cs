using DependencyInjection.Controllers;
using DependencyInjection.Models;
using System;
using Moq;
using Xunit;
using Microsoft.AspNetCore.Mvc;

namespace DependencyInjection.Tests
{
    public class DITests
    {
        [Fact]
        public void ControllerTest()
        {
            // Arrange
            var data = new[] { new Product { Name = "Test", Price = 100 } };
            var mock = new Mock<IRepository>();
            mock.SetupGet(m => m.Products).Returns(data);
            HomeController controller = new HomeController(mock.Object);
            // Act
            ViewResult result = controller.Index(new ProductTotalizer(mock.Object));
            // Assert
            Assert.Equal(data, result.ViewData.Model);
        }
    }
}
