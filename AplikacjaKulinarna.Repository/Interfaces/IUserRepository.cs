using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.User;

namespace AplikacjaKulinarna.Repository.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        new Task<User> GetAsync(Guid id); 
    }
}