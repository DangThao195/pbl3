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
        private readonly IUserService _customerService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IShoppingCartService _shoppingCartService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountService(ApplicationDbContext context, IUserService customerService, IPasswordHasher passwordHasher, IShoppingCartService shoppingCartService, IHttpContextAccessor httpContextAccessor)
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


        public async Task RegisterAsync(string name, string email, string sex, DateTime dateofbirth, string username,
string password, string address)
        {
            // Kiểm tra username tồn tại
            var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
            if (existingUser != null)
            {
                throw new InvalidOperationException($"User with username {username} already exists.");
            }

            using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                var userId = Guid.NewGuid();

                // Nếu bạn đang sử dụng TPT, chỉ cần thêm Customer (lớp con)
                // EF sẽ tự động xử lý phần User (lớp cha)
                var customer = new Customer
                {
                    UserID = userId,
                    Name = name,
                    Email = email,
                    Sex = sex,
                    DateOfBirth = dateofbirth,
                    UserName = username,
                    PassWord = _passwordHasher.HashPassword(password),
                    Address = address,
                    EarnedPoint = 0,
                    Role = "Customer"
                };

                // Thêm CUSTOMER vào context, KHÔNG thêm User riêng
                await _customerService.AddUserAsync(customer);

                // Tạo ShoppingCart
                var shoppingCart = new ShoppingCart
                {
                    CartID = Guid.NewGuid(),
                    UserID = userId
                };

                await _shoppingCartService.AddShoppingCartAsync(shoppingCart);

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                throw new Exception("Registration failed. Please try again.", ex);
            }
        }
    }
}
