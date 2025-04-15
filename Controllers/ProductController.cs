using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;
using System.Threading.Tasks;
using PBL3_HK4.Models;

namespace PBL3_HK4.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICatalogService _catalogService;
        public ProductController(ICatalogService catalogService, IProductService productService)
        {
            _catalogService = catalogService;
            _productService = productService;
        }

        [Route("Product/Details")]
        public async Task<IActionResult> Details(Guid id)
        {
            var listProduct = await _productService.GetAllProductsAsync();
            var product = await _productService.GetProductByIdAsync(id);
            var catalog = await _catalogService.GetCatalogByIdAsync(product.CatalogID);
            product.Catalog = catalog;

            var viewModel = new ProductDetailsViewModel
            {
                Product = product,
                ListProduct = listProduct
            };

            return View(viewModel);
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
    }
}
