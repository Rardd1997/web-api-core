using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace STOP.NET.REST.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class PingController : ControllerBase
    {
        private readonly ILogger<string> _logger;

        public PingController(ILogger<string> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string Get()
        {
            _logger.LogInformation("----- Invoked Ping Controller -----");
            return $"Server running...";
        }
    }
}