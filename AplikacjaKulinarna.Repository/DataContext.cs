using Microsoft.EntityFrameworkCore;

namespace AplikacjaKulinarna.Repository
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) :base(options)
        {
            
        }



    }
}