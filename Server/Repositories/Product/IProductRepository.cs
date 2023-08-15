
using System.ComponentModel.DataAnnotations;
using ProductTest.Shared.Models;

namespace ProductTest.Server.Repositories.Product
{
    public interface IProductRepository
    {
        IEnumerable<ProductModel> GetProducts();
        ProductModel GetProduct(string id);
        ProductModel AddProduct(ProductModel product);
        ProductModel UpdateProduct(ProductModel product);
        void DeleteProduct(string id);

    }
}