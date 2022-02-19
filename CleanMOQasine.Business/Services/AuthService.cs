using CleanMOQasine.Business.Configurations;
using CleanMOQasine.Business.Exceptions;
using CleanMOQasine.Business.Security;
using CleanMOQasine.Data.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

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
            var user = _userRepository.GetUserByLogin(login);
            if (user is null || !PasswordHash.ValidatePassword(password, user.Password))
                throw new AuthenticationException("Неверный логин или пароль.");

            var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.FirstName),
                                           new Claim(ClaimTypes.Surname, user.LastName),
                                           new Claim(ClaimTypes.Email, user.Email),
                                           new Claim(ClaimTypes.Role, user.Role.ToString())};
            var jwt = new JwtSecurityToken(
                issuer: AuthOptions.Issuer,
                audience: AuthOptions.Audience,
                claims: claims,
                expires: DateTime.UtcNow.Add(TimeSpan.FromDays(30)),
                signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
