using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using STOP.NET.REST.Interfaces;
using STOP.NET.REST.Models.Dto;

namespace STOP.NET.REST.Controllers
{
    
    [Route("api/v1/[controller]")]
    [Authorize]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody]RegisterDto model)
        {
            var user = _authService.Register(model);

            if (user == null)
                return BadRequest(new { message = "User not created" });

            return Ok(user);
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login([FromBody]LoginDto model)
        {
            var token = _authService.Login(model);

            if (token == null)
                return BadRequest(new { message = "Email or password is incorrect" });

            return Ok(token);
        }
    }
}