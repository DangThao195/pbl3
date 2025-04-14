﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PBL3_HK4.Entity;

#nullable disable

namespace PBL3_HK4.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("PBL3_HK4.Entity.Bill", b =>
                {
                    b.Property<Guid>("BillID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("Confirm")
                        .HasColumnType("bit");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<double>("TotalPrice")
                        .HasColumnType("float");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("BillID");

                    b.HasIndex("UserID");

                    b.ToTable("Bills", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.BillDetail", b =>
                {
                    b.Property<Guid>("BillDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BillID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("DiscountID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double?>("Price")
                        .HasColumnType("float");

                    b.Property<Guid?>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("BillDetailID");

                    b.HasIndex("BillID");

                    b.HasIndex("DiscountID");

                    b.HasIndex("ProductID");

                    b.ToTable("BillDetails", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.CartItem", b =>
                {
                    b.Property<Guid>("ItemID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CartID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<Guid>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ItemID");

                    b.HasIndex("CartID");

                    b.HasIndex("ProductID");

                    b.ToTable("CartItems", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Catalog", b =>
                {
                    b.Property<Guid>("CatalogID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CatalogName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("CatalogID");

                    b.ToTable("Catalogs", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Discount", b =>
                {
                    b.Property<Guid>("DiscountID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ApplicableProduct")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Describe")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<double?>("DiscountRate")
                        .HasColumnType("float");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Requirement")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("DiscountID");

                    b.ToTable("Discounts", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Product", b =>
                {
                    b.Property<Guid>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CatalogID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("EXPDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("MFGDate")
                        .HasColumnType("datetime2");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ProductDescription")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ProductName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("StockQuantity")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.HasIndex("CatalogID");

                    b.ToTable("Products", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Review", b =>
                {
                    b.Property<Guid>("ReviewID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("ProductID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("Rating")
                        .HasColumnType("int");

                    b.Property<string>("Text")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ReviewID");

                    b.HasIndex("ProductID");

                    b.HasIndex("UserID");

                    b.ToTable("Reviews", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.ShoppingCart", b =>
                {
                    b.Property<Guid>("CartID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("CartID");

                    b.HasIndex("UserID")
                        .IsUnique()
                        .HasFilter("[UserID] IS NOT NULL");

                    b.ToTable("ShoppingCarts", (string)null);
                });

            modelBuilder.Entity("PBL3_HK4.Entity.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("PassWord")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Phone")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sex")
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("UserName")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.HasKey("UserID");

                    b.ToTable("Users", (string)null);

                    b.HasDiscriminator().HasValue("User");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Customer", b =>
                {
                    b.HasBaseType("PBL3_HK4.Entity.User");

                    b.Property<string>("Address")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("EarnedPoint")
                        .HasColumnType("int");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Bill", b =>
                {
                    b.HasOne("PBL3_HK4.Entity.Customer", "Customer")
                        .WithMany("Bills")
                        .HasForeignKey("UserID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.BillDetail", b =>
                {
                    b.HasOne("PBL3_HK4.Entity.Bill", "Bill")
                        .WithMany("BillDetails")
                        .HasForeignKey("BillID");

                    b.HasOne("PBL3_HK4.Entity.Discount", "Discount")
                        .WithMany()
                        .HasForeignKey("DiscountID");

                    b.HasOne("PBL3_HK4.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID");

                    b.Navigation("Bill");

                    b.Navigation("Discount");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.CartItem", b =>
                {
                    b.HasOne("PBL3_HK4.Entity.ShoppingCart", "ShoppingCart")
                        .WithMany("Items")
                        .HasForeignKey("CartID");

                    b.HasOne("PBL3_HK4.Entity.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("ShoppingCart");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Product", b =>
                {
                    b.HasOne("PBL3_HK4.Entity.Catalog", "Catalog")
                        .WithMany("Products")
                        .HasForeignKey("CatalogID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Catalog");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Review", b =>
                {
                    b.HasOne("PBL3_HK4.Entity.Product", "Product")
                        .WithMany("Reviews")
                        .HasForeignKey("ProductID");

                    b.HasOne("PBL3_HK4.Entity.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("UserID");

                    b.Navigation("Customer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.ShoppingCart", b =>
                {
                    b.HasOne("PBL3_HK4.Entity.Customer", "Customer")
                        .WithOne("ShoppingCart")
                        .HasForeignKey("PBL3_HK4.Entity.ShoppingCart", "UserID");

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Bill", b =>
                {
                    b.Navigation("BillDetails");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Catalog", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Product", b =>
                {
                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.ShoppingCart", b =>
                {
                    b.Navigation("Items");
                });

            modelBuilder.Entity("PBL3_HK4.Entity.Customer", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("ShoppingCart");
                });
#pragma warning restore 612, 618
        }
    }
}
