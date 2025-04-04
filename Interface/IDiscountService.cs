using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace PBL3_HK4.Interface
{
    public interface IDiscountService
    {
        Task<IEnumerable<Discount>> GetAllDiscountsAsync();
        Task<Discount> GetDiscountByIdAsync(int discountId);
        Task<IEnumerable<Discount>> GetDiscountsByNameAsync(string discountName);
        Task AddDiscountAsync(Discount discount);
        Task UpdateDiscountAsync(Discount discount);
        Task DeleteDiscountAsync(int discountId);
    }
}
