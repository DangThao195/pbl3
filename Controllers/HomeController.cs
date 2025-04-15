using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Interface;

namespace PBL3_HK4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        public HomeController(IProductService productService)
        {
            _productService = productService;
        }

        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            var listProduct = await _productService.GetAllProductsAsync();
            return View("Index", listProduct);
        }
        
        public IActionResult ShoppingCart()
        {
            return View();
        }

        public IActionResult OrderSummary()
        {
            return View();
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }
    }
}
