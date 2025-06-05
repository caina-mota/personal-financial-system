using AuthService.Data.Dtos;
using AuthService.Models;
using AutoMapper;

namespace AuthService.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<CreateUserDto, User>(); // mapeia o objeto createuserdto para o modelo User
        }
    }
}
