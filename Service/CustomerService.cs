﻿using System.ComponentModel.DataAnnotations;
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
    public class CustomerService : ICustomerService
    {
        private readonly ApplicationDbContext _context;

        public CustomerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddCustomerAsync(Customer customer)
        {
            var currentUser = await _context.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.UserID == customer.UserID);
            if (currentUser != null)
            {
                throw new InvalidOperationException($"Customer with ID {customer.UserID} already exists.");
            }
            await _context.Users.AddAsync(customer);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCustomerAsync(Customer customer)
        {
            var currentUser = await _context.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.UserID == customer.UserID);
            if (currentUser == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customer.UserID} not found.");
            }
            _context.Users.Update(customer);
            await _context.SaveChangesAsync();
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid customerId)
        {
            var customer = await _context.Users.OfType<Customer>().Where(u => u.UserID == customerId).FirstOrDefaultAsync();
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with ID {customerId} not found.");
            }
            return customer;
        }

        public async Task<Customer> GetCustomerByUserNameAsync(string name)
        {
            var customer = await _context.Users.OfType<Customer>().Where(u => u.UserName == name).FirstOrDefaultAsync();
            if (customer == null)
            {
                throw new KeyNotFoundException($"Customer with name {name} not found.");
            }
            return customer;
        }
    }
}