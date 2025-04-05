using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_HK4.Interface
{
    public interface ICartItemService
    {
        public Task AddCartItemAsync(CartItem cartitem);
        public Task UpdateCartItemAsync(CartItem cartitem);
        public Task DeleteCartItemAsync(string cartitemid);
        public Task<CartItem> GetCartItemByIdAsync(string cartitemid);
        public Task<IEnumerable<CartItem> GetCartItemsByShoppingCartIdAsync(string shoppingcartid);
        public Task<IEnumerable<CartItem>> GetAllCartItemsAsync();
    }
}
