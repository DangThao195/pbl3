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
namespace PBL3_HK4.Service
{
    public class AccountAdminService : IAccountAdminService
    {
        private readonly ApplicationDbContext _context;
        private readonly IAdminService _adminService;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public AccountAdminService(ApplicationDbContext context, IAdminService admdinService, IPasswordHasher passwordHasher, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _adminService = admdinService;
            _passwordHasher = passwordHasher;
            _httpContextAccessor = httpContextAccessor;

        }
        public async Task ChangePasswordAsync(string username, string oldPassword, string newPassword)
        {
            var user = await _context.Users.OfType<Admin>().FirstOrDefaultAsync(u => u.UserName == username);
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

            await _adminService.UpdateAdminAsync(user);
        }

        public async Task LoginAsync(string username, string password)
        {
            var existingUser = await _context.Users.OfType<Admin>().FirstOrDefaultAsync(u => u.UserName == username);
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
    }
}
