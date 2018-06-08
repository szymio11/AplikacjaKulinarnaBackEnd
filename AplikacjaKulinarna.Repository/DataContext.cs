using AplikacjaKulinarna.Data.DbModels;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaKulinarna.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Recipe> Recipes { get; set; }

    }
}