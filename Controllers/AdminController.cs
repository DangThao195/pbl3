﻿using System;
using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using PBL3_HK4.Models;
using PBL3_HK4.Service;
namespace PBL3_HK4.Controllers
{
    public class AdminController : Controller
    {
        private readonly IProductService _productService;
        private readonly IDiscountService _discountService;
        private readonly ICatalogService _catalogService;
        private readonly IAdminService _adminService;


        public AdminController(IProductService productService, IDiscountService discountService, ICatalogService catalogService, IAdminService adminService)
        {
            _productService = productService;
            _discountService = discountService;
            _catalogService = catalogService;
            _adminService = adminService;
        }
        public IActionResult Home()
        {
            return View();
        }


        //Category Management
        [Route("/Admin/Category")]
        public async Task<IActionResult> Category()
        {
            var listCatalog = await _catalogService.GetAllCatalogsAsync();
            return View("Category", listCatalog);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(string name)
        {

            Catalog newCatalog = new Catalog
            {
                CatalogID = Guid.NewGuid(),
                CatalogName = name,
                Products = new List<Product>() 
            };

            await _catalogService.AddCatalogAsync(newCatalog);
            return RedirectToAction("Category");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateCategory(Guid id, string name)
        {

            Catalog catalog = new Catalog
            {
                CatalogID = id,
                CatalogName = name,
                Products = new List<Product>()
            };

           await _catalogService.UpdateCatalogAsync(catalog);

            return RedirectToAction("Category");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteCategory(Guid id)
        {
            await _catalogService.DeleteCatalogAsync(id);

            return RedirectToAction("Category");
        }

        //Discount Management
        [Route("/Admin/Discount")]
        public async Task<IActionResult> Discount()
        {
            var listDiscount = await _discountService.GetAllDiscountsAsync();
            return View("Discount", listDiscount);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDiscount(string name, double? discountRate, DateTime startDate, DateTime endDate, string describe = null, string applicableProduct = null, string requirement = null)
        {

            Discount newDiscount = new Discount
            {
                DiscountID = Guid.NewGuid(),
                Name = name,
                DiscountRate = discountRate,
                StartDate = startDate,
                EndDate = endDate,
                Describe = describe,
                ApplicableProduct = applicableProduct,
                Requirement = requirement
            };

            await _discountService.AddDiscountAsync(newDiscount);
            return RedirectToAction("Discount");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateDiscount(Guid id, string name, double? discountRate, DateTime startDate, DateTime endDate, string describe = null, string applicableProduct = null, string requirement = null)
        {

            Discount discount = new Discount
            {
                DiscountID = id,
                Name = name,
                DiscountRate = discountRate,
                StartDate = startDate,
                EndDate = endDate,
                Describe = describe,
                ApplicableProduct = applicableProduct,
                Requirement = requirement
            };

            await _discountService.UpdateDiscountAsync(discount);
            return RedirectToAction("Discount");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteDiscount(Guid id)
        {
            await _discountService.DeleteDiscountAsync(id);
            return RedirectToAction("Discount");
        }

        //Product Management
        public async Task<IActionResult> Product()
        {
            var viewModel = new ProductViewModel
            {
                Catalogs = await _catalogService.GetAllCatalogsAsync(),
                Products = await _productService.GetAllProductsAsync()
            };
            return View("Product", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CreateProduct(string productName, double price, int stockQuantity, Guid catalogID,
    DateTime mfgDate, DateTime expDate, string productDescription = null)
        {
            Product newProduct = new Product
            {
                ProductID = Guid.NewGuid(),
                ProductName = productName,
                ProductDescription = productDescription,
                Price = price,
                StockQuantity = stockQuantity,
                CatalogID = catalogID,
                MFGDate = mfgDate,
                EXPDate = expDate
            };
            await _productService.AddProductAsync(newProduct);
            return RedirectToAction("Product");
        }

        [HttpPost]
        public async Task<IActionResult> UpdateProduct(Guid id, string productName, double price, int stockQuantity,
            Guid catalogID, DateTime mfgDate, DateTime expDate, string productDescription = null)
        {
            // Lấy sản phẩm hiện có từ database
            var existingProduct = await _productService.GetProductByIdAsync(id);

            // Cập nhật thông tin sản phẩm
            existingProduct.ProductName = productName;
            existingProduct.ProductDescription = productDescription;
            existingProduct.Price = price;
            existingProduct.StockQuantity = stockQuantity;
            existingProduct.CatalogID = catalogID;
            existingProduct.MFGDate = mfgDate;
            existingProduct.EXPDate = expDate;

            // Lưu thay đổi
            await _productService.UpdateProductAsync(existingProduct);

            return RedirectToAction("Product");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteProduct(Guid id)
        {
            await _productService.DeleteProductAsync(id);
            return RedirectToAction("Product");
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Order()
        {
            return View();
        }

        public IActionResult Revenue()
        {
            return View();
        }


        [Route("/Admin/Profile")]
        public async Task<IActionResult> Profile()
        {
            var username = User.Identity.Name;
            User userProfile;
            userProfile = await _adminService.GetAdminByUserNameAsync(username);
            userProfile = (Admin)userProfile;
            return View("Profile", userProfile);
        }
    }
}