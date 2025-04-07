using Microsoft.AspNetCore.Mvc;

namespace PBL3_HK4.Controllers
{
    public class ProfileController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}