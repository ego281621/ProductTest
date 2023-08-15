using System.ComponentModel.DataAnnotations;
using ProductTest.Server.Models;
using ProductTest.Shared.Models;

namespace ProductTest.Server.Repositories.Product
{
    /// <summary>
    /// Represents a repository class for managing product data.
    /// </summary>
    public class ProductRepository : IProductRepository
    {
        private readonly ProductsDbContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductRepository"/> class.
        /// </summary>
        /// <param name="context">The database context for products.</param>
        public ProductRepository(ProductsDbContext context)
        {
            this.context = context;
        }

        /// <inheritdoc/>
        public IEnumerable<ProductModel> GetProducts()
        {
            return context.Products.Select(x => new ProductModel
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Price = x.Price
            }).OrderBy(x => x.Name);
        }

        /// <inheritdoc/>
        public ProductModel GetProduct(string id)
        {
            var result = context.Products.FirstOrDefault(x => x.Id == Guid.Parse(id));
            if (result != null)
            {
                return new ProductModel
                {
                    Id = result.Id,
                    Name = result.Name,
                    Price = result.Price,
                    Description = result.Description
                };
            }
            return new ProductModel();
        }

        /// <inheritdoc/>
        public ProductModel AddProduct(ProductModel product)
        {
            var newProduct = new Models.Product
            {
                Id = Guid.NewGuid(),
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            context.Products.Add(newProduct);
            context.SaveChanges();
            return product;
        }

        /// <inheritdoc/>
        public ProductModel UpdateProduct(ProductModel product)
        {
            var updateProduct = new Models.Product
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
            };

            context.Products.Update(updateProduct);
            context.SaveChanges();

            return product;
        }

        /// <inheritdoc/>
        public void DeleteProduct(string id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == Guid.Parse(id));
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }
    }
}
