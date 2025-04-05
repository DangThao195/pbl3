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
    public class BillService: IBillService
    {
        private readonly ApplicationDbContext _context;

        public BillService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Bill>> GetAllBillsAsync()
        {
            var listBill = await _context.Bills.ToListAsync();
            if (listBill == null || listBill.Count == 0)
            {
                throw new KeyNotFoundException("No bills found.");
            }
            return listBill;
        }

        public async Task<Bill> GetBillByIdAsync(Guid billId)
        {
            var bill = await _context.Bills.FirstOrDefaultAsync(b => b.BillID == billId);
            if (bill == null)
            {
                throw new KeyNotFoundException($"Bill with ID {billId} not found.");
            }
            return bill;
        }

        public async Task<IEnumerable<Bill>> GetBillsByCustomerIdAsync(Guid customerId)
        {
            var bills = await _context.Bills.Where(b => b.UserID == customerId).ToListAsync();
            if (bills == null || bills.Count == 0)
            {
                throw new KeyNotFoundException($"No bills found for customer ID {customerId}.");
            }
            return bills;
        }

        public async Task<IEnumerable<Bill>> GetBillsByDateAsync(DateTime date)
        {
            var bills = await _context.Bills.Where(b => b.Date.Date == date.Date).ToListAsync();
            if (bills == null || bills.Count == 0)
            {
                throw new KeyNotFoundException($"No bills found for date {date.ToShortDateString()}.");
            }
            return bills;
        }

        public async Task AddBillAsync(Bill bill)
        {
            var existingBill = await _context.Bills.FirstOrDefaultAsync(b => b.BillID == bill.BillID);
            if (existingBill != null)
            {
                throw new InvalidOperationException($"Bill with ID {bill.BillID} already exists.");
            }
            await _context.Bills.AddAsync(bill);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateBillAsync(Bill bill)
        {
            var existingBill = await _context.Bills.FirstOrDefaultAsync(b => b.BillID == bill.BillID);
            if (existingBill == null)
            {
                throw new KeyNotFoundException($"Bill with ID {bill.BillID} not found.");
            }
            _context.Bills.Update(bill);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBillAsync(Guid billId)
        {
            var bill = await GetBillByIdAsync(billId);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
                await _context.SaveChangesAsync();
            }
        }
    }
}
