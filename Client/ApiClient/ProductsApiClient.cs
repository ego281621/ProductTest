using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using ProductTest.Shared.Models;
using static System.Net.WebRequestMethods;

namespace ProductTest.Client
{
    public class ProductsApiClient
    {
        private readonly HttpClient http;

        public ProductsApiClient(HttpClient http)
        {
            this.http = http;
        }

        public virtual async Task<List<ProductModel>> GetProductsAsync()
        {
            return await http.GetFromJsonAsync<List<ProductModel>>("/api/products");
        }

        public virtual async Task<ProductModel> GetProductAsync(string id)
        {
            return await http.GetFromJsonAsync<ProductModel>($"/api/products/{id}");
        }

        public virtual async Task AddProductAsync(ProductModel product)
        {
            await http.PostAsJsonAsync("/api/products", product);
        }

        public virtual async Task UpdateProductAsync(ProductModel product)
        {
            await http.PutAsJsonAsync("/api/products", product);
        }

        public virtual async Task DeleteProductAsync(string id)
        {
            await http.DeleteAsync($"/api/products/{id}");
        }


        // other CRUD methods
    }
}