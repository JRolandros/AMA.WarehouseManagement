using AMA.WarehouseManagement.API.Common;
using AMA.WarehouseManagement.API.Controllers;
using AMA.WarehouseManagement.Application.Models;
using AMA.WarehouseManagement.Application.Services;
using AMA.WarehouseManagement.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AMA.WarehouseManagement.Tests
{
    public class ProductControllerTests
    {
        private readonly Mock<IProductService> _mockService;
        private readonly ProductController _productController;
        public ProductControllerTests()
        {
            _mockService = new Mock<IProductService>();
            _productController= new ProductController(_mockService.Object);
        }

        [Fact]
        public void GetProducts_ShouldReturnBadQuantityErrorMessage_WhenQuantityNegative()
        {
            //Act
            var result = _productController.GetProducts(-5);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);           
        }

        [Fact]
        public void GetProduct_ShouldReturnOkObjectResultWithWarehouseEntityEnumerable_WhenValid()
        {
            //Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { Quantity = 10 }))
                ))
                        .Returns(new List<QuantityProduct>
                        {
                            new QuantityProduct { ProductId=1, Quantity=30},
                            new QuantityProduct { ProductId=2, Quantity=10},
                            new QuantityProduct { ProductId=3, Quantity=40}
                        });

            //Act
            var result = _productController.GetProducts(10);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var dtos = Assert.IsAssignableFrom<IEnumerable<WarehouseEntity>>(okResult.Value);
            Assert.True(dtos.All(x => x.Quantity >= 10));
        }

        [Fact]
        public void AddProductStock_ShouldReturnBadQuantityErrorMessage_WhenQuantityNegative()
        {
            //Act
            var result = _productController.AddProductStock(1, -5);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);
        }

        [Fact]
        public void AddProductStock_ShouldReturnBadQuantityErrorMessage_WhenNoProduct()
        {
            //Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct>());

            //Act
            var result = _productController.AddProductStock(1, 5);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);
        }

        [Fact]
        public void AddProductStock_ShouldReturnBadQuantityErrorMessage_WhenNoCapacityProduct()
        {
            //Arrange
            _mockService.Setup(s => s.GetCapacityProducts(
                It.Is<Expression<Func<CapacityProduct, bool>>>(expr =>
                expr.Compile()(new CapacityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<CapacityProduct>());

            //Act
            var result = _productController.AddProductStock(1, 5);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);
        }

        [Fact]
        public void AddProductStock_ShouldReturnBadQuantityErrorMessage_WhenCapacityLessThanFinalQuantity()
        {
            //Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 100 } });

            _mockService.Setup(s => s.GetCapacityProducts(
                It.Is<Expression<Func<CapacityProduct, bool>>>(expr =>
                expr.Compile()(new CapacityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<CapacityProduct> { new CapacityProduct { ProductId = 1, Capacity = 150 } });

            //Act
            var result = _productController.AddProductStock(1, 100);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);
        }

        [Fact]
        public void AddProductStock_ShouldCallServiceWithCorrectQty()
        {
            // Arrange
            int productId = 1;
            int expectedQty = 110;

            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 10 } });

            _mockService.Setup(s => s.GetCapacityProducts(
                It.Is<Expression<Func<CapacityProduct, bool>>>(expr =>
                expr.Compile()(new CapacityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<CapacityProduct> { new CapacityProduct { ProductId = 1, Capacity = 150 } });

            // Act
            var result = _productController.AddProductStock(productId, 100);

            // Assert
            _mockService.Verify(s => s.SetProductQuantity(productId, expectedQty), Times.Once);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DispatchProduct_ShouldReturnBadQuantityErrorMessage_WhenQuantityNegative()
        {
            //Act
            var result = _productController.DispatchProduct(1, -3);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);
        }

        [Fact]
        public void DispatchProduct_ShouldReturnBadQuantityErrorMessage_WhenQuantityGreatherThanStock()
        {
            // Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 50 } });


            //Act
            var result = _productController.DispatchProduct(1, 100);

            //Assert
            Assert.IsType<BadQuantityErrorMessage>(result);
        }

        [Fact]
        public void DispatchProduct_ShouldCallServiceWithCorrectQty()
        {
            // Arrange
            int productId = 1;
            int expectedQty = 55;

            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 60 } });


            // Act
            var result = _productController.DispatchProduct(productId, 5);


            // Assert
            _mockService.Verify(s => s.SetProductQuantity(productId, expectedQty), Times.Once);

            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void DispatchProduct_ShouldReturnOkResult_WhenValid()
        {
            // Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 50 } });

            //Act
            var result = _productController.DispatchProduct(1, 3);

            //Assert
            Assert.IsType<OkResult>(result);
        }


        [Fact]
        public void SetProductCapacity_ShouldReturnBadCapacityErrorMessage_WhenCapacityLessThanCurrentQuantity()
        {
            // Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 50 } });

            //Act
            var result = _productController.SetProductCapacity(1, 10);

            //Assert
            Assert.IsType<BadCapacityErrorMessage>(result);
        }

        [Fact]
        public void SetProductCapacity_ShouldReturnOkResult_WhenValid()
        {
            // Arrange
            _mockService.Setup(s => s.GetQuantityProducts(
                It.Is<Expression<Func<QuantityProduct, bool>>>(expr =>
                expr.Compile()(new QuantityProduct { ProductId = 1 }))
                ))
                        .Returns(new List<QuantityProduct> { new QuantityProduct { ProductId = 1, Quantity = 50 } });

            //Act
            var result = _productController.SetProductCapacity(1, 100);

            //Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public void GetPage_ShouldReturnDataRangeByOffsetAndLimit()
        {
            //Arrange
            int offset=3, limit=5;
            _mockService.Setup(s => s.GetProductRange(0, 0))
                .Returns(new List<Product>
                {
                    new Product { ProductId = 1 },
                    new Product { ProductId = 2 },
                    new Product { ProductId = 3 },
                    new Product { ProductId = 4 },
                    new Product { ProductId = 5 },
                    new Product { ProductId = 6 },
                    new Product { ProductId = 7 },
                    new Product { ProductId = 8 },
                    new Product { ProductId = 9 },
                    new Product { ProductId = 10 },
                    new Product { ProductId = 11 },
                    new Product { ProductId = 12 }
                });

            //Act
            var result=_productController.GetPage(offset, limit);

            //Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var dtos = Assert.IsAssignableFrom<IEnumerable<ProductDto>>(okResult.Value);
            Assert.True(!dtos.Any(x => x.ProductId < 3 || x.ProductId > 8));

        }

    }
}
