using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AplikacjaKulinarna.Data.ModelsDto;
using AplikacjaKulinarna.Service.Extensions;
using AplikacjaKulinarna.Service.Interfaces;
using AplikacjaKulinarna.Service.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AplikacjaKulinarna.Service.Services
{
    public class JwtHandler : IJwtHandler
    {
        private readonly JwtSettings _jwtOptions;

        public JwtHandler(IOptions<JwtSettings> jwtOptions)
        {
            _jwtOptions = jwtOptions.Value;
        }
        public JwtDto CreateToken(Guid userId, string role)
        {
            var now = DateTime.UtcNow;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(ClaimTypes.Role, role),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimestamp().ToString())
            };
            var expires = now.AddMinutes(60);
            var key = Encoding.UTF8.GetBytes("super_hubert_nie_super_lokata");
            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                issuer: "http://localhost:44304/",
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials
                );
            var token =new JwtSecurityTokenHandler().WriteToken(jwt);
            return new JwtDto
            {
                Token = token,
                Expires = expires.ToTimestamp()
            };
        }
        
    }
}