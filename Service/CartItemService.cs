using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_HK4.Interface;
using PBL3_HK4.Entity;
using Microsoft.EntityFrameworkCore;

namespace PBL3_HK4.Service
{
    public class CartItemService : ICartItemService
    {
        private readonly ApplicationDbContext _context;

        public CartItemService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCartItemAsync(CartItem cartitem) 
        {
            var currentCartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ItemID == cartitem.ItemID);
            if (currentCartItem != null)
            {
                throw new InvalidOperationException($"Cart item with ID {cartitem.ItemID} already exists.");
            }
            await _context.CartItems.AddAsync(cartitem);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCartItemAsync(CartItem cartitem)
        {
            var currentCartItem = await _context.CartItems.FirstOrDefaultAsync(c => c.ItemID == cartitem.ItemID);
            if (currentCartItem == null)
            {
                throw new KeyNotFoundException($"Cart item with ID {cartitem.ItemID} not found.");
            }
            _context.CartItems.Update(cartitem);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteCartItemAsync(string cartitemId)
        {
            var cartitem = await _context.CartItems.FirstOrDefaultAsync(c => c.ItemID == cartitemId);
            if (cartitem == null)
            {
                throw new KeyNotFoundException($"Cart item with ID {cartitemId} not found.");
            }
            _context.CartItems.Remove(cartitem);
            await _context.SaveChangesAsync();
        }

        public async Task<CartItem> GetCartItemByIdAsync(string cartitemId)
        {
            var cartitem = await _context.CartItems.Where(c => c.ItemID == cartitemId).FirstOrDefaultAsync();
            if (cartitem == null)
            {
                throw new KeyNotFoundException($"Cart item with ID:{cartitemId} not found");
            }
            return cartitem;
        }

        public async Task<IEnumerable<CartItem>> GetCartItemsByShoppingCartIdAsync(string shoppingcartId)
        {
            var listCartItem = await _context.CartItems.Where(c => c.CartID == shoppingcartId).ToListAsync();
            if (listCartItem == null || listCartItem.Count == 0)
            {
                throw new KeyNotFoundException($"No cart item found for shopping cart ID {shoppingcartId}");
            }
            return listCartItem;
        }

        public async Task<INumerable<CartItem>> GetAllCartItemsAsync()
        {
            var listCartItem = await _context.CartItems.ToListAsync();
            if (listCartItem == null || listCartItem.Count == 0)
            {
                throw new KeyNotFoundException("No cart item found");
            }
            return listCartItem;
        }
    }
}
