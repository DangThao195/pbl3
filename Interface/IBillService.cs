using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_HK4.Entity;

namespace PBL3_HK4.Interface
{
    public interface IBillService
    {
        Task<IEnumerable<Bill>> GetAllBillsAsync();
        Task<Bill> GetBillByIdAsync(int billId);
        Task<IEnumerable<Bill>> GetBillsByCustomerIdAsync(string customerId);
        Task<IEnumerable<Bill>> GetBillsByDateAsync(DateTime date);
        Task AddBillAsync(Bill bill);
        Task UpdateBillAsync(Bill bill);
        Task DeleteBillAsync(int billId);
        Task<Dictionary<string, double>> FinancialStatisticAsync(DateTime startDate, DateTime endDate);
    }
}
