using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.User;
using AutoMapper;

namespace AplikacjaKulinarna.API.Helpers
{
    public class AutomapperUserProfile : Profile
    {
        public AutomapperUserProfile()
        {
            CreateMap<CreateUserDto, User>();
            CreateMap<User, UserDto>();
            CreateMap<User, AccountDto>();
        }   
    }
}