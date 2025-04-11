using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;

namespace PBL3_HK4.Controllers
{
    public class OrderController : Controller
    {
        private readonly IBillService _billService;
        private readonly IProductService _productService;
        public OrderController(IBillService billService, IProductService productService)
        {
            _billService = billService;
            _productService = productService;
        }

        [Authorize(Roles="Customer")]
        [HttpPost]
        public async Task<bool> ConfirmOrder(Customer customer, IEnumerable<CartItem> items, Discount? discount) 
        {
            if(items == null)
            {
                return false;
            }
            List<BillDetail> billDetails = new List<BillDetail>();
            var billid = Guid.NewGuid();
            foreach (var item in items)
            {
                var itemid = item.ProductID;
                int quantity = item.Quantity;
                var product = await _productService.GetProductByIdAsync(itemid);
                if (quantity > product.StockQuantity)
                    return false;
                else
                {
                    billDetails.Add(new BillDetail
                    {
                        BillDetailID = item.ItemID,
                        Quantity = quantity,
                        ProductID = product.ProductID,
                        BillID = billid,
                        DiscountID = discount?.DiscountID,
                        Price = product.Price,
                    });
                }
            }
            Bill bill = new Bill
            {
                BillID = billid,
                UserID = customer.UserID,
                Address = customer.Address,
                Date = DateTime.Now,
                BillDetails = billDetails
            };
            await _billService.AddBillAsync(bill);
            return true;
        }
    }
}
