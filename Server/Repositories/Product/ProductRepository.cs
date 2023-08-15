
using System.ComponentModel.DataAnnotations;
using ProductTest.Server.Models;
using ProductTest.Shared.Models;

namespace ProductTest.Server.Repositories.Product
{
    public class ProductRepository : IProductRepository
    {

        private readonly ProductsDbContext context;

        public ProductRepository(ProductsDbContext context)
        {
            this.context = context;
        }

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

        public ProductModel AddProduct(ProductModel product)
        {
            context.Products.Add(new Models.Product
            {
                Id = Guid.NewGuid(),
                Name= product.Name,
                Description = product.Description, 
                Price = product.Price,
            });

            context.SaveChanges();
            return product;
        }

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

        public void DeleteProduct(string id)
        {
            var product = context.Products.FirstOrDefault(x => x.Id == Guid.Parse(id));
            if(product != null)
                context.Products.Remove(product);
                context.SaveChanges();
        }

    }
}