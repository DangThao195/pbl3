using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;
using System.Threading.Tasks;
using PBL3_HK4.Service;
using Microsoft.AspNetCore.Authorization;
namespace PBL3_HK4.Controllers
{
    public class DiscountController : Controller
    {
        private readonly IDiscountService _discountService;

        public DiscountController(IDiscountService discountService)
        {
            _discountService = discountService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Views()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> AddDiscounttAsync(Discount discount)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _discountService.AddDiscountAsync(discount);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> UpdateDiscountAsync(Discount discount)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _discountService.UpdateDiscountAsync(discount);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> DeleteDiscountAsync(Guid id)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _discountService.DeleteDiscountAsync(id);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }
    }
}
