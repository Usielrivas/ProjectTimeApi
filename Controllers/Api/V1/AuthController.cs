using Microsoft.AspNetCore.Mvc;
using ProjectTimeApi.Services;
using ProjectTimeApi.DTOs;

namespace ProjectTimeApi.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<ActionResult<AuthOkDto>> Login([FromBody] LoginDto dto)
        {
            var token = await _authService.VerifyLogin(dto);

            if (token == null)
            {
                return Unauthorized(new { message = "Invalid email or password" });
            }

            return Ok(token);
        }

        [HttpPost("register")]
        public async Task<ActionResult<UserDto>> Register([FromBody] RegisterDto dto)
        {
            var user = await _authService.Register(dto);

            return Ok(user);
        }
    }
}



