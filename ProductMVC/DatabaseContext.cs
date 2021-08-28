using Microsoft.EntityFrameworkCore;
using ProductMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace ProductMVC
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
            Database.EnsureCreated();

            if (!Products.Any())
            {
                var products = new List<Product>
                {
                    new Product{ Name = "Product 1", Price = 109.99m },
                    new Product{ Name = "Product 2", Price = 208.01m },
                    new Product{ Name = "Product 3", Price = 307.55m },
                };

                Products.AddRange(products);
                SaveChanges();
            }
        }
    }
}
