using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.Recipe;
using AutoMapper;

namespace AplikacjaKulinarna.API.Helpers
{
    public class AutoMapperRecipeProfile : Profile
    {
        public AutoMapperRecipeProfile()
        {
            CreateMap<SaveRecipeDto, Recipe>();
            CreateMap<Recipe, RecipeDto>();
        }
    }
}