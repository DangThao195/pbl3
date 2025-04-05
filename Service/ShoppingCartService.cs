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
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly ApplicationDbContext _context;

        public ShoppingCartService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddShoppingCartAsync(ShoppingCart shoppingcart) 
        {
            var currentShoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(s => s.ShoppingCartID == shoppingcart.ShoppingCartID);
            if (currentShoppingCart != null)
            {
                throw new InvalidOperationException($"Shopping carts with ID {shoppingcart.ShoppingCartID} already exists.");
            }
            await _context.ShoppingCarts.AddAsync(shoppingcart);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateShoppingCartAsync(ShoppingCart shoppingcart)
        {
            var currentShoppingCart = await _context.ShoppingCarts.FirstOrDefaultAsync(s => s.ShoppingCartID == shoppingcart.ShoppingCartID);
            if (currentShoppingCart == null)
            {
                throw new KeyNotFoundException($"Shopping cart with ID {shoppingcart.ShoppingCartID} not found.");
            }
            _context.ShoppingCarts.Update(shoppingcart);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteShoppingCartAsync(string shoppingcartId)
        {
            var shoppingcart = await _context.ShoppingCarts.FirstOrDefaultAsync(s => s.ShoppingCartID == shoppingcartId);
            if (shoppingcart == null)
            {
                throw new KeyNotFoundException($"Shopping cart with ID {shoppingcartId} not found.");
            }
            _context.ShoppingCarts.Remove(shoppingcart);
            await _context.SaveChangesAsync();
        }

        public async Task<ShoppingCart> GetShoppingCartByIdAsync(string shoppingcartId)
        {
            var shoppingcart = await _context.ShoppingCarts.Where(s => s.ShoppingCartID == shoppingcartId).FirstOrDefaultAsync();
            if (shoppingcart) == null)
            { 
                throw new KeyNotFoundException($"Shopping cart with ID:{shoppingcartId} not found");
            }
            return shoppingcart;
        }

        public async Task<ShoppingCart> GetShoppingCartByCustomerIdAsync(string customerId)
        {
            var shoppingcart = await _context.ShoppingCarts.Where(s => s.UserID == customerId).FirstOrDefaultAsync();
            if (shoppingcart == null)
            {
                throw new KeyNotFoundException($"No shopping cart found for customer ID {customerId}");
            }
            return shoppingcart;
        }

        publuc async async Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync()
        {
            var listShoppingCart = await _context.ShoppingCarts.ToListAsync();
            if (listShoppingCart == null || listShoppingCart.Count == 0)
            {
                throw new KeyNotFoundException("No shopping cart found");
            }
            return listShoppingCart;
        }
    }
}
