using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using ProductTest.Server.Controllers;
using ProductTest.Server.Repositories.Product;
using ProductTest.Shared.Models;
using Xunit;

namespace ProductTest.Server.UnitTest
{
    public class ProductsControllerTests
    {
        private readonly Mock<IProductRepository> mockRepo;
        private readonly ProductsController controller;
        private Mock<ILogger<ProductsController>> logger;

        public ProductsControllerTests()
        {
            mockRepo = new Mock<IProductRepository>();
            logger = new Mock<ILogger<ProductsController>>();
            controller = new ProductsController(mockRepo.Object, logger.Object);
        }

        [Fact]
        public async Task GetProducts_ReturnsAllProducts()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetProducts())
              .Returns(GetTestProducts());

            // Act
            var result = await controller.GetProducts();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var products = Assert.IsType<List<ProductModel>>(okResult.Value);
            Assert.Equal(3, products.Count);
        }

        [Fact]
        public async Task GetProductById_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetProduct(string.Empty))
              .Returns((ProductModel)null);

            // Act
            var result = await controller.GetProduct(string.Empty);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        [Fact]
        public async Task CreateProduct_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange
            var product = new ProductModel() { Id = Guid.Empty, Description = "Test" };

            // Act
            var result = await controller.CreateProduct(product);

            // Assert
            Assert.IsType<ObjectResult>(result);
        }

        [Fact]
        public async Task UpdateProduct_WithInvalidModel_ReturnsBadRequest()
        {
            // Arrange

            // Act
            var result = await controller.UpdateProduct(null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task DeleteProduct_WithInvalidId_ReturnsNotFound()
        {
            // Arrange
            mockRepo.Setup(repo => repo.GetProduct(null))
              .Returns((ProductModel)null);

            // Act
            var result = await controller.DeleteProduct(string.Empty);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }

        private List<ProductModel> GetTestProducts()
        {
            return new List<ProductModel>(){
                  new ProductModel(){ Id = Guid.Parse("18856727-BBF3-4460-BE18-1175E649F6DC"), Name = "Product 1" },
                  new ProductModel(){ Id = Guid.Parse("3BF13B67-2E39-4C44-8553-45175D19A65B"), Name = "Product 2" },
                  new ProductModel(){ Id = Guid.Parse("AAD32900-5EFC-4109-B7A8-CFADAF534679"), Name = "Product 3" },
                };
        }
    }
}
