using System.ComponentModel.DataAnnotations;

namespace ProductTest.Shared.Models
{
    public class ProductModel
    {
        public Guid Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [Range(0, 1000)]
        [Required]
        public decimal? Price { get; set; }
    }
}