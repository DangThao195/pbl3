using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using PBL3_HK4.Models;
using PBL3_HK4.Service;

namespace PBL3_HK4.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IProductService _productService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly ICatalogService _catalogService;
        public HomeController(ICatalogService catalogService,IShoppingCartService shoppingCartService,IProductService productService, ICustomerService customerService)
        {
            _catalogService = catalogService;
            _shoppingCartService = shoppingCartService;
            _productService = productService;
            _customerService = customerService;
        }

        [Route("Home/Index")]
        public async Task<IActionResult> Index()
        {
            var products = await _productService.GetAllProductsAsync();
            var catalogs = await _catalogService.GetAllCatalogsAsync();
            var homeViewModel = new HomeViewModel
            {
                Products = products,
                Catalogs = catalogs,

            };
            return View("Index", homeViewModel);
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

        public async Task<IActionResult> OrderSummary()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var customer = await _customerService.GetCustomerByIdAsync(new Guid(userId));

            var cart = await _shoppingCartService.GetShoppingCartByCustomerIdAsync(new Guid(userId));
            var products = await _productService.GetAllProductsAsync();
            var cartItem = await _shoppingCartService.GetCartItemsByCartIDAsync(cart.CartID);
            cart.Items = cartItem;
            OrderSummaryViewModel orderSummaryViewModel = new OrderSummaryViewModel
            {
                ShoppingCart = cart,
                Products = products,
                Customer = customer
            };


            return View(orderSummaryViewModel);
        }

        public IActionResult AboutUs()
        {
            return View();
        }

        public IActionResult Support()
        {
            return View();
        }

        public IActionResult PlaceOrder()
        {
            return View();
        }
    }
}
