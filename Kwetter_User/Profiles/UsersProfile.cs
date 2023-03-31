using AutoMapper;
using Kwetter_User.DTO;
using Kwetter_User.Models;

namespace Kwetter_User.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile()
        {
            CreateMap<User, UserReadDTO>();
            CreateMap<UserCreateDTO, User>();
        }
    }
}
