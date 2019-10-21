using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using STOP.NET.REST.Data.Context;
using STOP.NET.REST.Helpers;
using STOP.NET.REST.Interfaces;
using STOP.NET.REST.Models;
using STOP.NET.REST.Models.Dto;

namespace STOP.NET.REST.Services
{
    public class AuthService : IAuthService
    {
        private readonly RESTContext _context;
        private readonly AppSettings _appSettings;

        public AuthService(IOptions<AppSettings> appSettings, RESTContext context)
        {
            _context = context;
            _appSettings = appSettings.Value;
        }

        public TokenDto Login(LoginDto login)
        {
            var credentials = _context.Credentials.SingleOrDefault(x => x.Email == login.Email && x.Password == login.Password);

            // return null if user not found
            if (credentials == null)
                return null;

            var user = _context.Users.Where(x => x.Id == credentials.UserId).SingleOrDefault();

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(_appSettings.Expires),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenDto = new TokenDto
            {
                Token = tokenHandler.WriteToken(token),
                Email = credentials.Email,
                Name = user.Name
            };

            return tokenDto;
        }

        public User Register(RegisterDto register)
        {
            var userId = Guid.NewGuid().ToString();
            var user = new User { Id = userId, Name = register.Name };

            _context.Users.Add(user);

            _context.Credentials.Add(new Credentials
            {
                Id = Guid.NewGuid().ToString(),
                UserId = userId,
                Email = register.Email,
                Password = register.Password
            });

            _context.SaveChanges();

            user.Credentials = null;

            return user;
        }
    }
}
