using Microsoft.AspNetCore.Mvc;
using FacturaWTW.API.Models;
using FacturaWTW.Infrastructure.Security;
using Microsoft.AspNetCore.Authorization;

namespace FacturaWTW.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [AllowAnonymous]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _config;
        public AuthController(IConfiguration config) => _config = config;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest req)
        {
            if (req.User == "AdminWTW" && req.Password == "AdminWTW")
            {
                var token = JwtHelper.GenerateToken(req.User, _config["Jwt:Key"]!, _config["Jwt:Issuer"]!, _config["Jwt:Audience"]!, int.Parse(_config["Jwt:ExpiresMinutes"]!));
                return Ok(new { token });
            }
            return Unauthorized();
        }
    }
}
