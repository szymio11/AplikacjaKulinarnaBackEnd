using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.ModelsDto.Recipe;

namespace AplikacjaKulinarna.Service.Interfaces
{
    public interface IRecipeService
    {
        Task<RecipeDto> CreateRecipeAsync(SaveRecipeDto saveRecipeDto, Guid userId);
        Task<RecipeDto> GetRecipeAsync(Guid id);
        Task UpdateRecipeAsync(SaveRecipeDto saveRecipeDto, Guid id);
        Task DeleteRecipe(Guid id);
    }
}