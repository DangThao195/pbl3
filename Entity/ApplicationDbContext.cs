﻿using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace PBL3_HK4.Entity
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IPasswordHasher _passwordHasher;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IPasswordHasher passwordHasher) : base(options) 
        {
            _passwordHasher = passwordHasher;
        }

        public DbSet<User> Users { get; set; }
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
            modelBuilder.Entity<Bill>().ToTable("Bills");
            modelBuilder.Entity<BillDetail>().ToTable("BillDetails");
            modelBuilder.Entity<Catalog>().ToTable("Catalogs");
            modelBuilder.Entity<Product>().ToTable("Products");
            modelBuilder.Entity<CartItem>().ToTable("CartItems");
            modelBuilder.Entity<Discount>().ToTable("Discounts");
            modelBuilder.Entity<Review>().ToTable("Reviews");
            modelBuilder.Entity<ShoppingCart>().ToTable("ShoppingCarts");

            // Setup inheritance (TPH)
            modelBuilder.Entity<User>()
                .HasDiscriminator<string>("Discriminator")
                .HasValue<Admin>("Admin")
                .HasValue<Customer>("Customer");
        }
    }
}
