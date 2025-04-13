using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;
using System.Threading.Tasks;
using PBL3_HK4.Service;
using Microsoft.AspNetCore.Authorization;

namespace PBL3_HK4.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Views()
        {
            return View();
        }

        [Authorize(Roles ="Admin")]
        [HttpPost]
        public async Task<IActionResult> AddProductAsync(Product product)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _productService.AddProductAsync(product);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateProductAsync(Product product)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _productService.UpdateProductAsync(product);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteProductAsync(Guid id)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            await _productService.DeleteProductAsync(id);

            return RedirectToAction("Index", "Home"); //Fix
        }
    }
}
