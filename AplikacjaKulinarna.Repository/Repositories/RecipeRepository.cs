using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Repository.Interfaces;

namespace AplikacjaKulinarna.Repository.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext context) : base(context)
        {
        }
    }
}