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
using System.Reflection.Metadata.Ecma335;
namespace PBL3_HK4.Controllers
{
    public class ReviewController : Controller
    {
        private readonly IReviewService _reviewService;

        public ReviewController(IReviewService reviewService)
        {
            _reviewService = reviewService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Views()
        {
            return View();
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> UpdateReviewAsync(Review review)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _reviewService.UpdateReviewAsync(review);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Customer")]
        [HttpPost]
        public async Task<IActionResult> AddReviewAsync(Review review)
        {
            if (!ModelState.IsValid) return View();
            try
            {
                await _reviewService.AddReviewAsync(review);

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
