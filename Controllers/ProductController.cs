using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Entity;

namespace PBL3_HK4.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Details()
        {
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        //[HttpPost]
        //public Product Create(Product product)
        //{
        //    return product;
        //}

        public IActionResult Views()
        {
            return View();
        }
    }
}
