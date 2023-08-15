using Microsoft.AspNetCore.Mvc;
using ProductTest.Server.Models;
using ProductTest.Server.Repositories.Product;
using ProductTest.Shared;
using ProductTest.Shared.Models;

namespace ProductTest.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {

        private readonly IProductRepository repository;
        private readonly ILogger<ProductsController> logger;
        private IProductRepository object1;
        private ProductsController object2;

        public ProductsController(IProductRepository repository, ILogger<ProductsController> logger)
        {
            this.repository = repository;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            try
            {
                var products = repository.GetProducts();
                return Ok(products);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting products");
                return StatusCode(500, "An error occurred while retrieving products.");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(string id)
        {
            try
            {
                var product = repository.GetProduct(id);

                if (product == null)
                    return NotFound();

                return Ok(product);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error getting product with id: {Id}", id);
                return StatusCode(500, "An error occurred while retrieving the product.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] ProductModel product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return StatusCode(400, ModelState);

                var created = repository.AddProduct(product);

                return CreatedAtAction(nameof(GetProduct), new { id = created.Id }, created);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error creating product");
                return StatusCode(500, "An error occurred while creating the product.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] ProductModel product)
        {
            try
            {
                if (product == null)
                    return BadRequest();

                if (!ModelState.IsValid)
                    return StatusCode(400, ModelState);

                var updated = repository.UpdateProduct(product);

                return Ok(updated);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error updating product with id: {Product Id}", product.Id);
                return StatusCode(500, "An error occurred while updating the product.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            try
            {
                var product = repository.GetProduct(id);

                if (product == null)
                    return NotFound();

                repository.DeleteProduct(id);
                return Ok();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Error deleting product with id: {Id}", id);
                return StatusCode(500, "An error occurred while deleting the product.");
            }
        }

    }
}