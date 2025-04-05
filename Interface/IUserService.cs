using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_HK4.Interface
{
    public interface IUserService
    {
        public Task AddUserAsync(User user);
        public Task UpdateUserAsync(User user);
        public Task<User> GetUserByIdAsync(string userId);
        public Task<IEnumerable<User> GetAllUsersAsync();
        public Task<string> GetRoleAsync(string username, string password);
    }
}
