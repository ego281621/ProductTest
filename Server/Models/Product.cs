using System;
using System.Collections.Generic;

namespace ProductTest.Server.Models
{
    /// <summary>
    /// Represents a product entity.
    /// </summary>
    public partial class Product
    {
        /// <summary>
        /// Gets or sets the unique identifier of the product.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Gets or sets the name of the product.
        /// </summary>
        public string? Name { get; set; }

        /// <summary>
        /// Gets or sets the description of the product.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the price of the product.
        /// </summary>
        public decimal? Price { get; set; }
    }
}
