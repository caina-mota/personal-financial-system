using AuthService.Data.Dtos;
using AuthService.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> RegisterUser(CreateUserDto dto)
        {
            await _userService.Register(dto);

            return Ok("User Registered");
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginUser(LoginUserDto dto)
        {
            var token = await _userService.Login(dto);

            return Ok(token);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _userService.Logout();

            return Ok("User logged out");
        }

        [HttpGet("me")]
        [Authorize]
        public async Task<IActionResult> GetUserData()
        {
            var userData = await _userService.GetUserData(User);

            return Ok($"{userData.UserName}\n{userData.BirthDate}");
        }
    }
}
