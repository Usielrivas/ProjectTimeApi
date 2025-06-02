using Microsoft.AspNetCore.Mvc;
using ProjectTimeApi.Services;
using ProjectTimeApi.DTOs;

namespace ProjectTimeApi.Controllers.Api.V1
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<UserDto>> Show(int id)
        {
            var user = await _userService.GetByIdAsync(id);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpGet]
        public async Task<ActionResult<List<UserDto>>> Index()
        {
            var users = await _userService.GetAllAsync();
            return Ok(users);
        }

        // POST api/v1/user
        [HttpPost]
        public async Task<ActionResult<UserDto>> Create([FromBody] CreateUserDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userService.CreateAsync(dto);

            return CreatedAtAction(nameof(Create), new { id = user.Id }, user);
        }
    }
}
