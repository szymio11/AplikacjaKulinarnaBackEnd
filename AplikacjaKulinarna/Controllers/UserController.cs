using System.Threading.Tasks;
using AplikacjaKulinarna.Data.ModelsDto.User;
using AplikacjaKulinarna.Service.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AplikacjaKulinarna.API.Controllers
{
    [Route("api/user")]
    public class UserController : ApiControllerBase
    {
        private readonly IUserService _service;

        public UserController(IUserService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Get()
        {
            var user = await _service.GetAccountAsync(UserId);
            return Ok(user);
        }

        [HttpPost("register")]
        public async Task<IActionResult> Create([FromBody] CreateUserDto createUser)
        {   
            await _service.RegisterUserAsync(createUser);
            return Ok();

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginDto loginDto)
        {
           var token =  await _service.LoginAsync(loginDto);
            return Ok(token);
        }
        
    }
}