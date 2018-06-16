using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;

namespace AplikacjaKulinarna.Repository.Interfaces
{
    public interface IRecipeRepository : IRepository<Recipe>
    {
        Task<Recipe> GetRecipeAllIncluding(Guid id);
    }
}