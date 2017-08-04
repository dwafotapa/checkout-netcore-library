using System;
using System.Collections.Generic;
using System.Linq;
using Checkout.ProductApi.NetCore.Controllers;
using Checkout.ProductApi.NetCore.Models;
using Checkout.ProductApi.NetCore.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace Checkout.ProductApi.NetCore.UnitTests.Controllers
{
    public class ProductControllerUnitTests
    {
        protected ProductController _controller;
        protected Mock<IProductRepository> _repository = new Mock<IProductRepository>();

        public ProductControllerUnitTests()
        {
            _controller = new ProductController(_repository.Object);
        }

        public class TheGetMethod : ProductControllerUnitTests
        {
            [Fact]
            public void ReturnsOk_WhenGettingAllTheProducts()
            {
                var products = TestHelper.MakeProducts();
                _repository.Setup(p => p.GetAll()).Returns(products);
                
                var result = (OkObjectResult)_controller.Get();

                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(products.Count(), ((IEnumerable<Product>)result.Value).Count());
            }

            [Fact]
            public void ReturnsNotFound_WhenProductDoesntExist()
            {
                var productName = "Fake Drink";
                _repository.Setup(p => p.Find(productName));
                
                var result = _controller.Get(productName);

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsOk_WhenProductExists()
            {
                var product = TestHelper.MakeProduct();
                _repository.Setup(p => p.Find(product.Name)).Returns(product);
                
                var result = (OkObjectResult)_controller.Get(product.Name);

                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(product.Name, ((Product)result.Value).Name);
                Assert.Equal(product.Quantity, ((Product)result.Value).Quantity);
            }
        }

        public class ThePostMethod : ProductControllerUnitTests
        {
            [Fact]
            public void ReturnsBadRequest_WhenProductAlreadyExists()
            {
                var product = TestHelper.MakeProduct();
                _repository.Setup(p => p.Find(product.Name)).Returns(product);
                
                var result = (BadRequestObjectResult)_controller.Post(product);

                Assert.IsType<BadRequestObjectResult>(result);
                Assert.Equal("Product already exists", result.Value);
            }

            [Fact]
            public void ReturnsOk_WhenProductDoesntExist()
            {
                var product = TestHelper.MakeProduct();
                
                var result = (OkObjectResult)_controller.Post(product);

                Assert.IsType<OkObjectResult>(result);
                Assert.Equal(product.Name, ((Product)result.Value).Name);
                Assert.Equal(product.Quantity, ((Product)result.Value).Quantity);
            }
        }

        public class ThePutMethod : ProductControllerUnitTests
        {
            [Fact]
            public void ReturnsNotFound_WhenProductDoesntExist()
            {
                var product = TestHelper.MakeProduct();
                
                var result = (NotFoundResult)_controller.Put(product);

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsOk_WhenProductDoesExist()
            {
                var product = TestHelper.MakeProduct();
                _repository.Setup(p => p.Find(product.Name)).Returns(product);
                
                var result = (OkResult)_controller.Put(product);

                Assert.IsType<OkResult>(result);
            }
        }

        public class TheDeleteMethod : ProductControllerUnitTests
        {
            [Fact]
            public void ReturnsNotFound_WhenProductDoesntExist()
            {
                var product = TestHelper.MakeProduct();
                
                var result = (NotFoundResult)_controller.Delete(product.Name);

                Assert.IsType<NotFoundResult>(result);
            }

            [Fact]
            public void ReturnsOk_WhenProductDoesExist()
            {
                var product = TestHelper.MakeProduct();
                _repository.Setup(p => p.Find(product.Name)).Returns(product);
                
                var result = (OkResult)_controller.Delete(product.Name);

                Assert.IsType<OkResult>(result);
            }
        }
    }
}
