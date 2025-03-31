using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace InterfaceService
{
    public interface ICustomerService
    {
        Task RegisterCustomerAsync(Customer customer);
        Task<Customer> LoginCustomerAsync(string email, string password);
        Task<Customer> GetCustomerAsync(string customerId);
        Task UpdateCustomerAsync(Customer customer);
        Task<ShoppingCart> GetShoppingCartAsync(string customerId);
        Task AddToCartAsync(string customerId, CartItem item);
        Task RemoveFromCartAsync(string customerId, string productId);
        
    }
}
