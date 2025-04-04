using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PBL3_HK4.Interface
{
    public interface ICustomerService
    {
        public Task RegisterCustomerAsync(Customer customer);
        public Task<Customer> LoginCustomerAsync(string email, string password);
        public Task<Customer> GetCustomerAsync(string customerId);
        public Task UpdateCustomerAsync(Customer customer);

    }
}
