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
using PBL3_HK4.Service;

namespace PBL3_HK4.Controllers
{
    public class AdminController : Controller, UserController
    {
        private readonly IBillDetailService _BillDetailService;
        private readonly IBillService _BillService;
        private readonly ICartItemService _CartItemService;
        private readonly ICatalogService _CatalogService;
        private readonly IDiscountService _DiscountService;
        private readonly IProductService _ProductService;
        private readonly IReviewService _ReviewService;
        private readonly IShoppingCartService _ShoppingCartService;
       
        public AdminController(IBillDetailService BillDetailService, IBillService BillService, ICartItemService CartItemService, 
            ICatalogService CatalogService, IDiscountService DiscountService, IProductService ProductService, IReviewService ReviewService,
            IShoppingCartService ShoppingCartService)
        {
            _BillDetailService = BillDetailService;
            _BillService = BillService;
            _CartItemService = CartItemService;
            _CatalogService = CatalogService;
            _DiscountService = DiscountService;
            _ProductService = ProductService;
            _ReviewService = ReviewService;
            _ShoppingCartService = ShoppingCartService;
        }
        public override async IActionResult RegisterAccountAsync()
        {

        }
        public override async IActionResult UpdateAccountAsync()
        {

        }
        public async IActionResult AddProductAsync()
        {

        }
        public async IActionResult UpdateProductAsync()
        {

        }
        public async IActionResult DeleteProductAsync()
        {

        }
        public async IActionResult AddCatalogAsync()
        {

        }
        public async IActionResult UpdateCatalogAsync()
        {

        }
        public async IActionResult DeleteCatalogAsync()
        {

        }
        public async IActionResult AddDiscountAsync()
        {

        }
        public async IActionResult UpdateDiscountAsync()
        {

        }
        public async IActionResult DeleteDiscountAsync()
        {

        }
        public async IActionResult UpdateBillAsync()
        {

        }
        public async IActionResult DeleteBillAsync()
        {

        }
        public async IActionResult CalculateRevenueByDateAsync()
        {

        }
    }
}