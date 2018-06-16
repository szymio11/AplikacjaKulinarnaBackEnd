using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaKulinarna.Repository.Repositories
{
    public class RecipeRepository : Repository<Recipe>, IRecipeRepository
    {
        public RecipeRepository(DataContext context) : base(context)
        {
        }

        public async Task<Recipe> GetRecipeAllIncluding(Guid id) => 
            await _context.Recipes
                .Include(u=>u.User)
                .Include(r=>r.Ratings)
                .SingleOrDefaultAsync(a=>a.Id==id);
    }
}