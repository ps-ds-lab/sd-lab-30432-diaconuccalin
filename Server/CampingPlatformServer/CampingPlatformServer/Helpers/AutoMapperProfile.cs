using AutoMapper;
using CampingPlatformServer.Model;
using CampingPlatformServer.Model.Users;

namespace CampingPlatformServer.Helpers
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, UserModel>();
            CreateMap<RegisterModel, User>();
            CreateMap<UpdateModel, User>();
        }
    }
}
