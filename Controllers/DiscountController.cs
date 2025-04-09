using Microsoft.AspNetCore.Mvc;

namespace PBL3_HK4.Controllers
{
    public class DiscountController : Controller
    {
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
    }
}
