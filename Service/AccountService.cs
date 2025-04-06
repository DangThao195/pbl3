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
namespace PBL3_HK4.Service
{
    public class AccountService : IAccountService
    {
        private readonly ApplicationDbContext _context;
        private readonly ICustomerService _customerService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(ApplicationDbContext context, ICustomerService customerService, IPasswordHasher passwordHasher, IShoppingCartService shoppingCartService, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _customerService = customerService;
            _passwordHasher = passwordHasher;
            _shoppingCartService = shoppingCartService;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            var user = await _context.Customers.FirstOrDefaultAsync(u => u.UserName == username);
            if (user == null)
            {
                throw new InvalidOperationException($"User with username {username} not found.");
            }

            bool isValidOldPassword = _passwordHasher.VerifyPassword(user.PassWord, oldPassword);
            if (!isValidOldPassword)
            {
                throw new InvalidOperationException("Current password is incorrect.");
            }
            user.PassWord = _passwordHasher.HashPassword(newPassword);

            await _customerService.UpdateUserAsync(user);
            return true;
        }

        public async Task<bool> LoginAsync(string username, string password)
        {
            var existingUser = await _context.Customers.FirstOrDefaultAsync(u => u.UserName == username);
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
            return true;
        }

        public async Task Logout()
        {
            if (_httpContextAccessor?.HttpContext != null)
            { 
            
                await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                _httpContextAccessor.HttpContext.Session.Clear();
            }
        }
        

        public async Task<bool> RegisterAsync(string name, string email, string sex, DateTime dateofbirth, string username,
            string password, string address)
        {
            var existingUser = await _context.Customers.FirstOrDefaultAsync(u => u.UserName == username);
            if (existingUser != null)
            {
                throw new InvalidOperationException($"User with username {username} already exists.");
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
                UserName = username,
                PassWord = _passwordHasher.HashPassword(password),
                EarnedPoint = 0,
                Role = "Customer",
                CartID = cartid
            };
            ShoppingCart shoppingCart = new ShoppingCart
            {
                CartID = cartid,
                CustomerID = newcustomer.UserID
            };
            newcustomer.ShoppingCart = shoppingCart;
            await _customerService.AddUserAsync(newcustomer);
            await _shoppingCartService.AddShoppingCartAsync(shoppingCart);
            return true;
        }
    }
}
