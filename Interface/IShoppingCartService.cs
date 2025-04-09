using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_HK4.Interface
{
    public interface IShoppingCartService
    {
        public Task AddShoppingCartAsync(ShoppingCart shoppingcart) ;
        public Task UpdateShoppingCartAsync(ShoppingCart shoppingcartc);
        public Task DeleteShoppingCartAsync(Guid shoppingcartId);
        public Task<ShoppingCart> GetShoppingCartByIdAsync(Guid shoppingcartId);
        public Task<ShoppingCart> GetShoppingCartByCustomerIdAsync(Guid customerId);
        public Task<IEnumerable<ShoppingCart>> GetAllShoppingCartsAsync();
    }
}
