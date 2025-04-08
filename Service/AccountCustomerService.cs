using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_HK4.Interface;
using PBL3_HK4.Entity;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
namespace PBL3_HK4.Service
{
    public class AccountCustomerService : IAccountCustomerService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _customerService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountCustomerService(ApplicationDbContext context, ICustomerService customerService, IPasswordHasher passwordHasher, IShoppingCartService shoppingCartService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _customerService = customerService;
            _passwordHasher = passwordHasher;
            _shoppingCartService = shoppingCartService;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            var user = await _context.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new InvalidOperationException($"Customer with username {username} not found.");
            }

            bool isValidOldPassword = _passwordHasher.VerifyPassword(user.PassWord, oldPassword);
            if (!isValidOldPassword)
            {
                throw new InvalidOperationException("Current password is incorrect.");
            }
            user.PassWord = _passwordHasher.HashPassword(newPassword);

            await _customerService.UpdateCustomerAsync(user);
        }

        public async Task LoginAsync(string username, string password)
        {
            var existingUser = await _context.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.UserName == username);
            if (existingUser == null)
            {
                throw new InvalidOperationException($"Invalid username or password.");
            }
            var hashedPassword = existingUser.PassWord;
            bool isValid = _passwordHasher.VerifyPassword(hashedPassword, password);
            if (!isValid)
            {
                throw new InvalidOperationException($"Invalid username or password.");
            }
        }

        public async Task Logout()
        {
            if (_httpContextAccessor?.HttpContext != null)
            { 
            
                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                _httpContextAccessor.HttpContext.Session.Clear();
            }
        }
        
        public async Task RegisterAsync(string name, string email, string sex, DateTime dateofbirth, string username, string phone,
            string password, string address)
        {
            var existingUser = await _context.Users.OfType<Customer>().FirstOrDefaultAsync(u => u.UserName == username);
            if (existingUser != null)
            {
                throw new InvalidOperationException($"Customer with username {username} already exists.");
            }
            var userid = Guid.NewGuid();
            var cartid = Guid.NewGuid();
            Customer newcustomer = new Customer
            {
                UserID = userid,
                Name = name,
                Email = email,
                Sex = sex,
                DateOfBirth = dateofbirth,
                Address = address,
                Phone = phone,
                UserName = username,
                PassWord = _passwordHasher.HashPassword(password),
                EarnedPoint = 0,
                Role = "Customer"
            };
            ShoppingCart shoppingCart = new ShoppingCart
            {
                CartID = cartid,
                UserID = newcustomer.UserID
            };
            newcustomer.ShoppingCart = shoppingCart;
            await _customerService.AddCustomerAsync(newcustomer);
            await _shoppingCartService.AddShoppingCartAsync(shoppingCart);
        }
    }
}
