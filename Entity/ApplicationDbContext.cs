
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PBL3_HK4.Entity
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
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
            modelBuilder.Entity<User>().ToTable("Users");
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

            modelBuilder.Entity<Customer>()
                .HasOne(c => c.ShoppingCart)
                .WithOne(sc => sc.Customer)
                .HasForeignKey<ShoppingCart>(sc => sc.CustomerID);

            modelBuilder.Entity<BillDetail>()
                .HasOne(bd => bd.Product)
                .WithMany()
                .HasForeignKey(bd => bd.ProductID);

            modelBuilder.Entity<BillDetail>()
                .HasOne(bd => bd.Bill)
                .WithMany(b => b.BillDetails)
                .HasForeignKey(bd => bd.BillID);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Product)
                .WithMany()
                .HasForeignKey(ci => ci.ProductID);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.ShoppingCart)
                .WithMany(sc => sc.Items)
                .HasForeignKey(ci => ci.CartID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Product)
                .WithMany(p => p.Reviews)
                .HasForeignKey(r => r.ProductID);

            modelBuilder.Entity<Review>()
                .HasOne(r => r.Customer)
                .WithMany()
                .HasForeignKey(r => r.CustomerID);
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Catalog)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CatalogID);
        }
    }
}
