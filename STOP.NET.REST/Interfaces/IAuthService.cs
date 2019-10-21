using STOP.NET.REST.Models;
using STOP.NET.REST.Models.Dto;

namespace STOP.NET.REST.Interfaces
{
    public interface IAuthService
    {
        User Register(RegisterDto register);
        TokenDto Login(LoginDto login);
    }
}
