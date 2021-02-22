using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using wmj.userManagerServer.Domain.Interfaces;
using wmj.userManagerServer.Domain.Models;

namespace wmj.userManagerServer.Domain.Services
{
    public class TokenServices: ITokenServices
    {
        private readonly AppConfig _settings;

        public TokenServices(IOptions<AppConfig> settings)
        {
            _settings = settings.Value;
        }
        public string GenerateToken(IEnumerable<Claim> claims)
        {
            int expireTime = _settings.Jwt.ExpireTime;
            string issuer = _settings.Jwt.Issuer;
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.Jwt.Key));
            var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(issuer, issuer,
                expires: DateTime.Now.AddMinutes(expireTime), claims: claims, signingCredentials: cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
