using System.Collections.Generic;
using Kolmeo.API.Model;
using Microsoft.EntityFrameworkCore;

namespace Kolmeo.API.Context
{
    public class InMemoryContext : DbContext
    {
        public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .HasData(
                    new List<Product>
                    {
                        new Product { Id = 1, Name = "Canon D9", Description = "A second generation camera with HD videos", Price = 250},
                        new Product { Id = 2, Name = "Sony A7", Description = "Lorem ipsum dolor sit amet consectetur.", Price = 300},
                        new Product { Id = 3, Name = "Nikon Z", Description = "A multi-featured camera with timer", Price = 249.99}
                    }
                );

            base.OnModelCreating(modelBuilder);
        }
    }
}