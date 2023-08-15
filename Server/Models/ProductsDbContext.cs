using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ProductTest.Server.Models
{
    /// <summary>
    /// Represents the database context for managing products.
    /// </summary>
    public partial class ProductsDbContext : DbContext
    {
        public ProductsDbContext()
        {
        }

        public ProductsDbContext(DbContextOptions<ProductsDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet of products in the database.
        /// </summary>
        public virtual DbSet<Product> Products { get; set; }

        /// <summary>
        /// Configures the entity models and relationships for the database context.
        /// </summary>
        /// <param name="modelBuilder">The model builder.</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                // Configure properties of the "Product" entity
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsUnicode(false);
                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                entity.Property(e => e.Price).HasColumnType("decimal(18, 9)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        // Partial method that can be implemented in a separate file
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
