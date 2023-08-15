using System.ComponentModel.DataAnnotations;
using ProductTest.Shared.Models;

namespace ProductTest.Server.Repositories.Product
{
    /// <summary>
    /// Represents a repository interface for managing product data.
    /// </summary>
    public interface IProductRepository
    {
        /// <summary>
        /// Retrieve all products.
        /// </summary>
        /// <returns>An enumerable collection of product models.</returns>
        IEnumerable<ProductModel> GetProducts();

        /// <summary>
        /// Retrieve a specific product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to retrieve.</param>
        /// <returns>A product model if found, otherwise null.</returns>
        ProductModel GetProduct(string id);

        /// <summary>
        /// Add a new product.
        /// </summary>
        /// <param name="product">The product model to be added.</param>
        /// <returns>The added product model.</returns>
        ProductModel AddProduct(ProductModel product);

        /// <summary>
        /// Update an existing product.
        /// </summary>
        /// <param name="product">The updated product model.</param>
        /// <returns>The updated product model.</returns>
        ProductModel UpdateProduct(ProductModel product);

        /// <summary>
        /// Delete a product by its ID.
        /// </summary>
        /// <param name="id">The ID of the product to be deleted.</param>
        void DeleteProduct(string id);
    }
}
