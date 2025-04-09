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
    public class CategoryController : Controller
    {
        private readonly ICatalogService _catalogService;

        public CategoryController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
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
        [Route("/Catalog")]
        public async Task<IActionResult> AddCatalogAsync(Catalog catalog)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _catalogService.AddCatalogAsync(catalog);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("/Catalog")]
        public async Task<IActionResult> UpdateCatalogAsync(Catalog catalog)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            try
            {
                await _catalogService.UpdateCatalogAsync(catalog);

                return RedirectToAction("Index", "Home"); //Fix
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(); //Fix
            }
        }

        [Authorize(Roles = "Admin")]
        [Route("/Catalog/{id}")]
        public async Task<IActionResult> DeleteCatalogAsync(Guid id)
        {
            if (!ModelState.IsValid)
                return View(); //Fix
            await _catalogService.DeleteCatalogAsync(id);

            return RedirectToAction("Index", "Home"); //Fix
        }

    }
}
