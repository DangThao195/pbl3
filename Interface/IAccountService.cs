using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_HK4.Entity;
using Microsoft.EntityFrameworkCore;
namespace PBL3_HK4.Interface
{
    public interface IAccountService
    {
        public Task RegisterAsync(string name, string email, string sex, DateTime dateofbirth, string username,
            string password, string address);
        public Task<bool> LoginAsync(string username, string password);
        public Task<bool> ChangePasswordAsync(string username, string oldPassword, string newPassword);
        public Task Logout();
    }
}
