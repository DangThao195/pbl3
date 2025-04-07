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
        public Task AddUserAsync(Customer user);
        public Task UpdateUserAsync(Customer user);
        public Task<Customer> GetUserByIdAsync(Guid userId);
        public Task<string> GetRoleAsync(string username, string password);
    }
}
