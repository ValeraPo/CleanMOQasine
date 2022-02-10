using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CleanMOQasine.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository _userRepository;

        public AuthService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public string Login(string login, string password)
        {
            var user = _userRepository.Login(login, password);
            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.FirstName),
                                           new Claim(ClaimTypes.Surname, user.LastName),
                                           new Claim(ClaimTypes.Email, user.Email),
                                           new Claim(ClaimTypes.MobilePhone, user.PhoneNumber)};

            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromMinutes(30)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
