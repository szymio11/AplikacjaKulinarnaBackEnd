using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaKulinarna.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository 
    {
        public UserRepository(DataContext context) : base(context)
        {
        }
        public async  Task<User> GetAsync(Guid id)
        {
            return await _context.Users.SingleOrDefaultAsync(a => a.Id == id);
        }
     
    }
}