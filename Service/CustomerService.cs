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
    public class CustomerService: ICustomerService
    {
        private readonly ApplicationDbContext _context;
        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task RegisterCustomerAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == customer.Email);
            if (existingCustomer != null)
            {
                throw new InvalidOperationException($"Customer with email {customer.Email} already exists.");
            }
            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();
        }
        public async Task<Customer> LoginCustomerAsync(string email, string password)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.Email == email && c.PassWord == password);
            if (customer == null)
            {
                throw new InvalidOperationException("Invalid email or password.");
            }
            return customer;
        }
        public async Task<Customer> GetCustomerAsync(string customerId)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.UserID == customerId);
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }
            return customer;
        }
        public async Task UpdateCustomerAsync(Customer customer)
        {
            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.UserID == customer.UserID);
            if (existingCustomer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customer.UserID} not found.");
            }
            _context.Customers.Update(customer);
            await _context.SaveChangesAsync();
        }
    }
}
