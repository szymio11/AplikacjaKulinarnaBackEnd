using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;

namespace AplikacjaKulinarna.Repository.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> GetRecipeAllIncluding(Guid id);
        Task<IEnumerable<Recipe>> GetRecipesAsync();
    }
}