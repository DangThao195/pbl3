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
        public Task<IEnumerable<Bill>> GetAllBillsAsync();
        public Task<Bill> GetBillByIdAsync(string billId);
        public Task<IEnumerable<Bill>> GetBillsByCustomerIdAsync(string customerId);
        public Task<IEnumerable<Bill>> GetBillsByDateAsync(DateTime date);
        public Task AddBillAsync(Bill bill);
        public Task UpdateBillAsync(Bill bill);
        public Task DeleteBillAsync(string billId);
    }
}
