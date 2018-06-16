using System.Linq;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.Rating;
using AplikacjaKulinarna.Data.ModelsDto.Recipe;
using AplikacjaKulinarna.Data.ModelsDto.User;
using AutoMapper;

namespace AplikacjaKulinarna.API.Helpers
{
    public class AutoMapperRecipeProfile : Profile
    {
        public AutoMapperRecipeProfile()
        {
            CreateMap<SaveRecipeDto, Recipe>();
            CreateMap<Recipe, RecipeDto>()
                .ForMember(gdt => gdt.Rating,
                    otp => otp.MapFrom(src => src.Ratings.Any() ? src.Ratings.Select(a=>a.Value).Average() : src.Ratings.Count))
                 .ForMember(dto=>dto.User,opt=>opt.MapFrom( u=>
                    new AccountDto
                {
                    Email = u.User.Email,
                    Id =u.User.Id,
                    Name = u.User.Name,
                    Role = u.User.Role
                }))
                ;
        }
    }
}