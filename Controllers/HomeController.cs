using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Interface;
using PBL3_HK4.Models;
using PBL3_HK4.Service;

namespace PBL3_HK4.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        public HomeController(IShoppingCartService shoppingCartService,IProductService productService)
        {
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }

        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            var listProduct = await _productService.GetAllProductsAsync();
            return View("Index", listProduct);
        }
        

        public async Task<IActionResult> ShoppingCart()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _shoppingCartService.GetShoppingCartByCustomerIdAsync(new Guid(userId));
            var products = await _productService.GetAllProductsAsync();
            var cartItem = await _shoppingCartService.GetCartItemsByCartIDAsync(cart.CartID);
            cart.Items = cartItem;
            var viewmodel = new ShoppingCartViewModel
            {
                ShoppingCart = cart,
                Products = products
            };

            return View(viewmodel);
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
