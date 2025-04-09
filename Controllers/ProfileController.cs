using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Threading.Tasks;
namespace PBL3_HK4.Controllers
{
    public class ProfileController : Controller
    {
        private readonly ICustomerService _customerService;
        public ProfileController(ICustomerService customerService)
        {
            _customerService = customerService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Profile/Index")]
        public async Task<IActionResult> ShowProfile()
        {
            var username = User.Identity.Name;
            var userProfile = await _customerService.GetCustomerByUserNameAsync(username);
            return View("Index", userProfile);//  can FE view ra ...
        }
    }
}
