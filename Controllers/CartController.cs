using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;

namespace PBL3_HK4.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartItemService _cartItemService;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IProductService _productService;

        public CartController(ICartItemService cartItemService, IShoppingCartService shoppingCartService, IProductService productService)
        {
            _cartItemService = cartItemService;
            _shoppingCartService = shoppingCartService;
            _productService = productService;
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(Guid productId, int quantity)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var cart = await _shoppingCartService.GetShoppingCartByCustomerIdAsync(new Guid(userId));
            if (cart == null)
            {
                var newCart = new ShoppingCart
                {
                    UserID = new Guid(userId),
                    CartID = Guid.NewGuid()

                };
                await _shoppingCartService.AddShoppingCartAsync(newCart);
                cart = newCart;
            }
            var existingItems = await _cartItemService.GetCartItemsByShoppingCartIdAsync(cart.CartID);
            var existingItem = existingItems.FirstOrDefault(i => i.ProductID == productId);

            if (existingItem != null)
            {
                existingItem.Quantity += quantity;
                await _cartItemService.UpdateCartItemAsync(existingItem);
            }
            else
            {
                var product = await _productService.GetProductByIdAsync(productId);
                var newItem = new CartItem
                {
                    ItemID = Guid.NewGuid(),
                    CartID = cart.CartID,
                    ProductID = productId,
                    Quantity = quantity,
                    Price = product.Price
                };
                await _cartItemService.AddCartItemAsync(newItem);
            }

            return Json(new
            {
                success = true,
                message = "Item is added to shopping cart successfully"
            });
        }
        public async Task<IEnumerable<CartItem>> GetCartItems()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var cart = await _shoppingCartService.GetShoppingCartByCustomerIdAsync(new Guid(userId));
            return cart.Items;
        }

    }
}