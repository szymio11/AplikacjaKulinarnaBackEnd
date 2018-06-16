using System;
using AplikacjaKulinarna.Data.ModelsDto;

namespace AplikacjaKulinarna.Service.Interfaces
{
    public interface IJwtHandler
    {
        JwtDto CreateToken(Guid userId, string email, string name, string role);
    }
}
