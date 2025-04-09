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
    public class AdminService : IAdminService
    {
        private readonly ApplicationDbContext _context;

        public AdminService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task AddAdminAsync(Admin admin)
        {
            var currentUser = await _context.Users.OfType<Admin>().FirstOrDefaultAsync(u => u.UserID == admin.UserID);
            if (currentUser != null)
            {
                throw new InvalidOperationException($"Admin with ID {admin.UserID} already exists.");
            }
            await _context.Users.AddAsync(admin);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdminAsync(Admin admin) 
        {
            var currentUser = await _context.Users.OfType<Admin>().FirstOrDefaultAsync(u => u.UserID == admin.UserID);
            if (currentUser == null)
            {
                throw new KeyNotFoundException($"Admin with ID {admin.UserID} not found.");
            }
            _context.Users.Update(admin);
            await _context.SaveChangesAsync();
        }

        public async Task<Admin> GetAdminByIdAsync(Guid adminId)
        {
            var admin = await _context.Users.OfType<Admin>().Where(u => u.UserID == adminId).FirstOrDefaultAsync();
            if (admin == null)
            {
                throw new KeyNotFoundException($"Admin with ID {adminId} not found.");
            }
            return admin;
        }

        public async Task<Admin> GetAdminByNameAsync(string name)
        {
            var admin = await _context.Users.OfType<Admin>().Where(u => u.UserName == name).FirstOrDefaultAsync();
            if (admin == null)
            {
                throw new KeyNotFoundException($"Admin with name {name} not found.");
            }
            return admin;
        }
    }
}
