using System;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Entity;

namespace PBL3_HK4.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Home()
        {
            return View();
        }

        public IActionResult Category()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateCategory(string name)
        {
            Debug.WriteLine($"Đã nhận được dữ liệu Category: Name = {name}");

            Catalog newCatalog = new Catalog
            {
                CatalogID = Guid.NewGuid(),
                CatalogName = name,
                Products = new List<Product>() 
            };

            Debug.WriteLine($"Đã tạo Catalog: ID = {newCatalog.CatalogID}, Name = {newCatalog.CatalogName}");
            return RedirectToAction("Category");
        }

        [HttpPost]
        public IActionResult UpdateCategory(Guid id, string name)
        {
            Debug.WriteLine($"Đã nhận được dữ liệu cập nhật Category: ID = {id}, Name = {name}");

            Catalog catalog = new Catalog
            {
                CatalogID = id,
                CatalogName = name,
                Products = new List<Product>()
            };

            Debug.WriteLine($"Đã cập nhật Catalog: ID = {catalog.CatalogID}, Name = {catalog.CatalogName}");

            return RedirectToAction("Category");
        }

        [HttpPost]
        public IActionResult DeleteCategory(Guid id)
        {
            Debug.WriteLine($"Đã nhận yêu cầu xóa Category: ID = {id}");

            return RedirectToAction("Category");
        }

        public IActionResult Discount()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateDiscount(string name, double? discountRate, DateTime startDate, DateTime endDate, string describe = null, string applicableProduct = null, string requirement = null)
        {
            Debug.WriteLine($"CreateDiscount - Name: {name}, Rate: {discountRate}, Start: {startDate}, End: {endDate}, Describe: {describe}, Products: {applicableProduct}, Requirements: {requirement}");

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

            return RedirectToAction("Discount");
        }

        [HttpPost]
        public IActionResult UpdateDiscount(Guid id, string name, double? discountRate, DateTime startDate, DateTime endDate, string describe = null, string applicableProduct = null, string requirement = null)
        {
            Debug.WriteLine($"UpdateDiscount - ID: {id}, Name: {name}, Rate: {discountRate}, Start: {startDate}, End: {endDate}, Describe: {describe}, Products: {applicableProduct}, Requirements: {requirement}");

            return RedirectToAction("Discount");
        }

        [HttpPost]
        public IActionResult DeleteDiscount(Guid id)
        {
            Debug.WriteLine($"DeleteDiscount - ID: {id}");

            return RedirectToAction("Discount");
        }

        public IActionResult Product()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateProduct(string productName, double price, int stockQuantity, Guid catalogID,
            DateTime mfgDate, DateTime expDate, string productDescription = null)
        {
            Debug.WriteLine($"CreateProduct - Name: {productName}, Price: {price}, Stock: {stockQuantity}, CatalogID: {catalogID}, MFG: {mfgDate}, EXP: {expDate}, Description: {productDescription}");

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
            return RedirectToAction("Product");
        }

        [HttpPost]
        public IActionResult UpdateProduct(Guid id, string productName, double price, int stockQuantity,
            Guid catalogID, DateTime mfgDate, DateTime expDate, string productDescription = null)
        {
            Debug.WriteLine($"UpdateProduct - ID: {id}, Name: {productName}, Price: {price}, Stock: {stockQuantity}, CatalogID: {catalogID}, MFG: {mfgDate}, EXP: {expDate}, Description: {productDescription}");

            return RedirectToAction("Product");
        }

        [HttpPost]
        public IActionResult DeleteProduct(Guid id)
        {
            Debug.WriteLine($"DeleteProduct - ID: {id}");

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

        public IActionResult Profile()
        {
            return View();
        }
    }
}