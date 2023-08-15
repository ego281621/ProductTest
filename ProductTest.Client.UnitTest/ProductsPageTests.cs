using Bunit;
using Bunit.TestDoubles;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using ProductTest.Client;
using ProductTest.Client.Pages;
using ProductTest.Shared.Models;
using System;
using System.Threading.Tasks;
using Xunit;

namespace ProductTest.Client.Tests
{

    public class ProductsPageTests: TestContext
    {

        [Fact]
        public void DisplaysLoadingText()
        {
            // Arrange
            var mockHttp = new Mock<HttpClient>();
            mockHttp.Object.BaseAddress = new Uri("https://example.com");

            var productsApiClient = new ProductsApiClient(mockHttp.Object);

            var productsPage = new TestContext();
            productsPage.Services.AddSingleton(productsApiClient);

            // Act
            var cut = productsPage.RenderComponent<ProductList>();

            // Assert
            cut.Markup.Contains("Loading...");
        }

        [Fact]
        public async Task LoadsAndDisplaysProducts()
        {
            // Arrange
            var products = GetTestProducts();

            var mockHttp = new Mock<HttpClient>();
            mockHttp.Object.BaseAddress =  new Uri("https://example.com");

            var productsApiClient = new ProductsApiClient(mockHttp.Object);

            var mockClient = new Mock<ProductsApiClient> ();
            mockClient.Setup(x => x.GetProductsAsync())
              .ReturnsAsync(products);

            var productsPage = new TestContext();
            productsPage.Services.AddSingleton(productsApiClient);

            // Act
            var cut = productsPage.RenderComponent<ProductList>();

            // Assert
            cut.Markup.Contains("Product 1");
            cut.Markup.Contains("Product 2");
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

