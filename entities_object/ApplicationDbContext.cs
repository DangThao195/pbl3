using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace entities_object
{
     public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<CartItem> CartItems { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Customer>().ToTable("Customers");

            modelBuilder.Entity<Admin>().ToTable("Admins");

            modelBuilder.Entity<Bill>().ToTable("Bills");

            modelBuilder.Entity<BillDetail>().ToTable("BillDetails");

            modelBuilder.Entity<Catalog>().ToTable("Catalogs");

            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<CartItem>().ToTable("CartItems");

            modelBuilder.Entity<Discount>().ToTable("Discounts");

            modelBuilder.Entity<Review>().ToTable("Reviews");

            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCarts");

            // Example of seeding data
            string customerJson = System.IO.File.ReadAllText("Customers.json");
            List<Customer> customers = System.Text.Json.JsonSerializer.Deserialize<List<Customer>>(customerJson);
            foreach (Customer customer in customers)
            {
                modelBuilder.Entity<Customer>().HasData(customer);
            }
            string adminJson = System.IO.File.ReadAllText("Admins.json");
            List<Admin> admins = System.Text.Json.JsonSerializer.Deserialize<List<Admin>>(adminJson);
            foreach (Admin admin in admins)
            {
                modelBuilder.Entity<Admin>().HasData(admin);
            }
            string billJson = System.IO.File.ReadAllText("Bills.json");
            List<Bill> bills = System.Text.Json.JsonSerializer.Deserialize<List<Bill>>(billJson);
            foreach (Bill bill in bills)
            {
                modelBuilder.Entity<Bill>().HasData(bill);
            }
            string billDetailJson = System.IO.File.ReadAllText("BillDetails.json");
            List<BillDetail> billDetails = System.Text.Json.JsonSerializer.Deserialize<List<BillDetail>>(billDetailJson);
            foreach (BillDetail billDetail in billDetails)
            {
                modelBuilder.Entity<BillDetail>().HasData(billDetail);
            }
            string catalogJson = System.IO.File.ReadAllText("Catalogs.json");
            List<Catalog> catalogs = System.Text.Json.JsonSerializer.Deserialize<List<Catalog>>(catalogJson);
            foreach (Catalog catalog in catalogs)
            {
                modelBuilder.Entity<Catalog>().HasData(catalog);
            }
            string productJson = System.IO.File.ReadAllText("Products.json");
            List<Product> products = System.Text.Json.JsonSerializer.Deserialize<List<Product>>(productJson);
            foreach (Product product in products)
            {
                modelBuilder.Entity<Product>().HasData(product);
            }
            string cartItemJson = System.IO.File.ReadAllText("CartItems.json");
            List<CartItem> cartItems = System.Text.Json.JsonSerializer.Deserialize<List<CartItem>>(cartItemJson);
            foreach (CartItem cartItem in cartItems)
            {
                modelBuilder.Entity<CartItem>().HasData(cartItem);
            }
            string discountJson = System.IO.File.ReadAllText("Discounts.json");
            List<Discount> discounts = System.Text.Json.JsonSerializer.Deserialize<List<Discount>>(discountJson);
            foreach (Discount discount in discounts)
            {
                modelBuilder.Entity<Discount>().HasData(discount);
            }
            string reviewJson = System.IO.File.ReadAllText("Reviews.json");
            List<Review> reviews = System.Text.Json.JsonSerializer.Deserialize<List<Review>>(reviewJson);
            foreach (Review review in reviews)
            {
                modelBuilder.Entity<Review>().HasData(review);
            }
            string shoppingCartJson = System.IO.File.ReadAllText("ShoppingCarts.json");
            List<ShoppingCart> shoppingCarts = System.Text.Json.JsonSerializer.Deserialize<List<ShoppingCart>>(shoppingCartJson);
            foreach (ShoppingCart shoppingCart in shoppingCarts)
            {
                modelBuilder.Entity<ShoppingCart>().HasData(shoppingCart);
            }

        }
    }
}
