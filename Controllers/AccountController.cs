using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PBL3_HK4.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAdminService _adminService;
        private readonly IAccountService _accountService;

        public AccountController(ICustomerService customerService, IAdminService adminService, IAccountService accountService)
        {
            _customerService = customerService;
            _accountService = accountService;
            _adminService = adminService;
        }

        public IActionResult Main()
        {
            return View();
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Customer customer)
        {
            if (!ModelState.IsValid)
                return View(customer);
            try
            {
                await _accountService.RegisterAsync(customer.Name, customer.Email, customer.Sex, customer.DateOfBirth, customer.UserName, customer.Phone,
                  customer.PassWord, customer.Address);

                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(customer);
            }
        }


        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignIn(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var userLogin = await _accountService.LoginAsync(user.UserName, user.PassWord);

                // Tạo Claims để xác thực người dùng
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, userLogin.UserName),
                new Claim(ClaimTypes.NameIdentifier, userLogin.UserID.ToString()),
                new Claim(ClaimTypes.Role, userLogin is Customer ? "Customer" : "Admin")
            };

                var claimsIdentity = new ClaimsIdentity(
                    claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                );
                var authProperties = new AuthenticationProperties
                {
                    IsPersistent = true,
                    ExpiresUtc = DateTimeOffset.UtcNow.AddHours(24)
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties
                );
                // Điều hướng dựa trên loại user
                if (userLogin is Customer)
                {
                    return RedirectToAction("Index", "Home"); // Giao diện của Customer
                }
                else
                {
                    return RedirectToAction("Index", "Home"); // Giao diện của Admin
                }
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View(user);
            }

        }
        public IActionResult Signout()
        {
            return View();
        }
        public async Task<IActionResult> SignOut()
        {
            await _accountService.Logout();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                if (user.NewPassWord.IsNullOrEmpty())
                {
                    ModelState.AddModelError(string.Empty, "New password cannot be empty.");
                    return View(user);
                }
                await _accountService.ChangePasswordAsync(user.UserName, user.PassWord, user.NewPassWord);
                return RedirectToAction("Index", "Home");
            }
            catch (InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
                return View();
            }
        }

        
    }
}