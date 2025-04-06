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
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;

        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddUserAsync(User user)
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (currentUser != null)
            {
                throw new InvalidOperationException($"User with ID {user.UserID} already exists.");
            }
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateUserAsync(User user) 
        {
            var currentUser = await _context.Users.FirstOrDefaultAsync(u => u.UserID == user.UserID);
            if (currentUser == null)
            {
                throw new KeyNotFoundException($"User with ID {user.UserID} not found.");
            }
            _context.Users.Update(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserByIdAsync(Guid userId)
        {
            var user = await _context.Users.Where(u => u.UserID == userId).FirstOrDefaultAsync();
            if (user == null)
            {
                throw new KeyNotFoundException($"User with ID:{userId} not found");
            }
            return user;
        }

        public async Task<IEnumerable<User>> GetAllUsers()
        {
            var listUser = await _context.Users.ToListAsync();
            if (listUser == null || listUser.Count == 0)
            {
                throw new KeyNotFoundException("User not found");
            }
            return listUser;
        }

        public async Task<string> GetRoleAsync(string username, string password)
        {
            var user = await _context.Users.FirstOrDefaultAsync(c => c.UserName == username && c.PassWord == password);
            if (user == null)
            {
                throw new InvalidOperationException("Invalid username or password.");
            }
            return user.Role;
        }

        public Task<IEnumerable<User>> GetAllUsersAsync()
        {
            throw new NotImplementedException();
        }
    }
}
