using AuthService.Data.Dtos;
using AuthService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

namespace AuthService.Services
{
    public class UserService
    {
        private IMapper _mapper;
        private UserManager<User> _userManager;
        private SignInManager<User> _signInManager;
        private TokenService _tokenService;

        public UserService(IMapper mapper, UserManager<User> userManager, SignInManager<User> signInManager, TokenService tokenService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
        }

        public async Task Register(CreateUserDto dto)
        {
            User user = _mapper.Map<User>(dto);
            IdentityResult res = await _userManager.CreateAsync(user, dto.Password);

            if(!res.Succeeded)
            {
                throw new ApplicationException($"Failed to Create New User \n{res.ToString()}");
            }
        }

        public async Task<string> Login(LoginUserDto dto)
        {
            var result = await _signInManager.PasswordSignInAsync(dto.UserName, dto.Password, false, false);

            if(!result.Succeeded)
            {
                throw new ApplicationException("User Unnauthenticated");
            }

            var user = _signInManager.UserManager.Users.FirstOrDefault(user => user.NormalizedUserName == dto.UserName.ToUpper());
            var token = _tokenService.GenerateToken(user);

            return token;
        }

        public async Task Logout()
        {
            await _signInManager.SignOutAsync();
        }

        internal async Task<User> GetUserData(ClaimsPrincipal claims)
        {
            var id = claims.FindFirstValue("id");
            var userData = await _userManager.FindByIdAsync(id);

            if (userData == null)
            {
                throw new ApplicationException("No user data found");
            }

            return userData;
        }
    }
}
