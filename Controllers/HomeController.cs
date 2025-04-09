using Microsoft.AspNetCore.Mvc;

namespace PBL3_HK4.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        
        public IActionResult ShoppingCart()
        {
            return View();
        }

        public IActionResult OrderSummary()
        {
            return View();
        }

        
    }
}
