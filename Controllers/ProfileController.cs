using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;
using System.Threading.Tasks;
namespace PBL3_HK4.Controllers
{
    public class ProfileController : Controller
    {

        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;
        public ProfileController(ICustomerService customerService, IAdminService adminService)
        {
            _customerService = customerService;
            _adminService = adminService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [Route("/Profile/Index")]
        public async Task<IActionResult> ShowProfile()
        {
            var username = User.Identity.Name;
            var role = User.FindFirstValue(ClaimTypes.Role);
            User userProfile;
            if (role == "Customer")
            {
                userProfile = await _customerService.GetCustomerByUserNameAsync(username);
                userProfile = (Customer)userProfile;
            }
            else
            {
                userProfile = await _adminService.GetAdminByUserNameAsync(username);
                userProfile = (Admin)userProfile;
            }
            return View("Index", userProfile);
        }

        [HttpPost]
        public async Task UpdateProfile(User user)
        {
            var role = User.FindFirstValue(ClaimTypes.Role);
            if (role == "Customer")
            {
                await _customerService.UpdateCustomerAsync((Customer)user);
            }
            else
            {
                await _adminService.UpdateAdminAsync((Admin)user);
            }
        }
    }
}