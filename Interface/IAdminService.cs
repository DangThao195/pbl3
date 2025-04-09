using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL3_HK4.Interface
{
    public interface IAdminService
    {
        public Task AddAdminAsync(Admin admin);
        public Task UpdateAdminAsync(Admin admin);
        public Task<Admin> GetAdminByIdAsync(Guid adminId);
        public Task<Admin> GetAdminByUserNameAsync(string name);

        public Task<(double TotalRevenue, int TotalBill)> RevenueByDateAsync(DateTime date);
        public Task<(double TotalRevenue, int TotalBill)> RevenueByMonthAsync(int month, int year);

        public Task<(double TotalRevenue, int TotalBill)> RevenueByYearAsync(int year);
    }
}