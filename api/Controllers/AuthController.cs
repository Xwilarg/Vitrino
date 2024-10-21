using Microsoft.AspNetCore.Mvc;

namespace Vitrino.API.Controllers
{
    [ApiController]
    [Route("/api/auth/")]
    public class AuthController : ControllerBase
    {
        private readonly ILogger<AuthController> _logger;

        public AuthController(ILogger<AuthController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public bool Get()
        {
            return true;
        }
    }
}
