using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductTest.Shared.Models;
using static System.Net.WebRequestMethods;

namespace ProductTest.Client
{
    /// <summary>
    /// Represents a client for making API requests related to products.
    /// </summary>
    public class ProductsApiClient
    {
        private readonly HttpClient http;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductsApiClient"/> class.
        /// </summary>
        /// <param name="http">The HTTP client for making requests.</param>
        public ProductsApiClient(HttpClient http)
        {
            this.http = http;
        }

        /// <summary>
        /// Retrieves a list of products asynchronously.
        /// </summary>
        /// <returns>A list of product models.</returns>
        public virtual async Task<List<ProductModel>> GetProductsAsync()
        {
            return await http.GetFromJsonAsync<List<ProductModel>>("/api/products");
        }

        /// <summary>
        /// Retrieves a product by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>The retrieved product model.</returns>
        public virtual async Task<ProductModel> GetProductAsync(string id)
        {
            return await http.GetFromJsonAsync<ProductModel>($"/api/products/{id}");
        }

        /// <summary>
        /// Adds a new product asynchronously.
        /// </summary>
        /// <param name="product">The product model to add.</param>
        public virtual async Task AddProductAsync(ProductModel product)
        {
            await http.PostAsJsonAsync("/api/products", product);
        }

        /// <summary>
        /// Updates an existing product asynchronously.
        /// </summary>
        /// <param name="product">The updated product model.</param>
        public virtual async Task UpdateProductAsync(ProductModel product)
        {
            await http.PutAsJsonAsync("/api/products", product);
        }

        /// <summary>
        /// Deletes a product by its ID asynchronously.
        /// </summary>
        /// <param name="id">The ID of the product to delete.</param>
        public virtual async Task DeleteProductAsync(string id)
        {
            await http.DeleteAsync($"/api/products/{id}");
        }

        // Other CRUD methods can be added here
    }
}
