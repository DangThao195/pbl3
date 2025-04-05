using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PBL3_HK4.Interface;
using PBL3_HK4.Entity;
using Microsoft.EntityFrameworkCore;
using PBL3_HK4.Service;

namespace PBL3_HK4.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _UserService;
        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }
        public override async IActionResult RegisterAccountAsync()
        {

        }
        public override async IActionResult UpdateAccountAsync()
        {
        
        }
        public async IActionResult LoginAsync()
        {

        }
        public async IActionResult LogoutAsync()
        {

        }
    }
}