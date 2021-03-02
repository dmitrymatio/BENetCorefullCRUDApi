using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AngularFullCRUD.DataHelpers
{
    public class Product
    {

        [Key]
        public int ProduceID { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }

    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data.
            modelBuilder.Entity<Product>().HasData(
                new { ProduceID = 1, Description = "Oranges", Price = 4 },
                new { ProduceID = 2, Description = "Apples", Price = 3 },
                new { ProduceID = 3, Description = "Pears", Price = 5 }
            );
        }
    }

}
