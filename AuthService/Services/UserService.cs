using AuthService.Data.Dtos;
using AuthService.Models;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

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



    }
}
