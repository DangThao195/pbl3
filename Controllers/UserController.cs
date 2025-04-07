using Microsoft.AspNetCore.Mvc;
using PBL3_HK4.Entity;
using PBL3_HK4.Interface;

namespace PBL3_HK4.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : Controller
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            // Kiểm tra xem Email hoặc UserName đã tồn tại chưa
            var existingUser = await _userService.GetUserByEmailOrUserNameAsync(newUserDto.Email, newUserDto.UserName);
            if (existingUser != null)
                return Conflict(new { message = "Email hoặc Username đã được sử dụng." });

            var newUser = new User
            {
                UserID = Guid.NewGuid(),
                Name = newUserDto.Name,
                Email = newUserDto.Email,
                Sex = newUserDto.Sex,
                DateOfBirth = newUserDto.DateOfBirth,
                UserName = newUserDto.UserName,
                PassWord = newUserDto.PassWord, // Lưu ý: nên mã hóa mật khẩu ở đây
                Role = newUserDto.Role
            };

            await _userService.CreateUserAsync(newUser);

            return Ok(new { message = "Đăng ký thành công!", userId = newUser.UserID });
        }
    }

}
