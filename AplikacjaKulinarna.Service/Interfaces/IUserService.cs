using System;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.ModelsDto.User;

namespace AplikacjaKulinarna.Service.Interfaces
{
    public interface IUserService
    {
        Task<AccountDto> GetAccountAsync(Guid userId);
        Task RegisterUserAsync(CreateUserDto createUserDto);
        Task<TokenDto> LoginAsync(LoginDto loginDto);
    }
}