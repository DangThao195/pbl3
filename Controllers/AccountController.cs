using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;

namespace PBL3_HK4.Controllers
{
    public class AccountController : Controller
    {
        private readonly ICustomerService _customerService;
        private readonly IAccountCustomerService _accountCustomerService;

        public AccountController(ICustomerService customerService, IAccountCustomerService accountCustomerService)
        {
            _customerService = customerService;
            _accountCustomerService = accountCustomerService;
        }

        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(Customer customer)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            await _accountCustomerService.RegisterAsync(customer.Name, customer.Email, customer.Sex, customer.DateOfBirth, customer.UserName, customer.Phone,
                customer.PassWord, customer.Address);

            return RedirectToAction("Index", "Home");
        }
 

        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SignIn(User user)
        {
            // Successful login
            return RedirectToAction("Index", "Home");
        }

    }
}