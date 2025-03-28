using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace entities_object
{
     public class CustomerDbContext: DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        //   public DbSet<ShoppingCart> ShoppingCarts {get; set;}
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");
            string customerJson = System.IO.File.ReadAllText("");
            List<Customer> customers = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(customerJson);
            foreach(Customer customer in customers)
            {
                modelBuilder.Entity<Customer>().HasData(customer);
            }

        }
    }
}
