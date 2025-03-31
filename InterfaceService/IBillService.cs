using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
namespace InterfaceService
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
        Task <Dictionary<string, double>>FinancialStatisticAsync(DateTime startDate, DateTime endDate);
        Task AddBillDetailAsync(BillDetail billDetail);
        Task<IEnumerable<BillDetail>> GetBillDetailsByBillIdAsync(string billId);
        
    }
}
