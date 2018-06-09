using System;
using System.Linq;
using System.Threading.Tasks;
using AplikacjaKulinarna.Data.DbModels;
using AplikacjaKulinarna.Data.ModelsDto.User;
using AplikacjaKulinarna.Repository.Interfaces;
using AplikacjaKulinarna.Service.Interfaces;
using AutoMapper;

namespace AplikacjaKulinarna.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;
        private readonly IJwtHandler _jwtHandler;

        public UserService(IUserRepository repository,IMapper mapper,IJwtHandler jwtHandler)
        {
            _repository = repository;
            _mapper = mapper;
            _jwtHandler = jwtHandler;
        }

        public async Task<AccountDto> GetAccountAsync(Guid userId)
        { 
            if (!await _repository.ExistAsync(x=>x.Id==userId))
            {
                throw new Exception("Nie ma takiego Używtkownika");
            }
            var user = await _repository.GetAsync(userId);
            var result = _mapper.Map<AccountDto>(user);
            return result;

        }

        public async Task RegisterUserAsync(CreateUserDto createUserDto)
        {
            if (await _repository.ExistAsync(a=>a.Email==createUserDto.Email))
            {
                throw new Exception("Taki Mail Już istnieje");
            }
            var user = _mapper.Map<CreateUserDto, User>(createUserDto);
            user.Created = DateTime.UtcNow;
            user.Role = "User";
            await _repository.AddAsyn(user);
        }

        public async Task<TokenDto> LoginAsync(LoginDto loginDto)
        {
            
            if (!await _repository.ExistAsync(a=>a.Email==loginDto.Email)) 
            {
                throw new Exception("Nie ma takiego użytkownika o tym loginie");
            }
            var users = await _repository.FindAllAsync(a => a.Email == loginDto.Email);
            var user = users.Single();
            if (user.Password!=loginDto.Password)
            {
                throw new Exception("Złe Hasło!");
            }

            var token = _jwtHandler.CreateToken(user.Id, user.Role);
            return new TokenDto
            {
                Token = token.Token,
                Expires = token.Expires,
                Role = user.Role
            };
        }
    }
}