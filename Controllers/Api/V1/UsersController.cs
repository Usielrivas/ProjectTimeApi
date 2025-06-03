using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ProjectTimeApi.Services;
using ProjectTimeApi.DTOs;

namespace ProjectTimeApi.Controllers.Api.V1
{
    [ApiController]
    [Authorize]
    [Route("api/v1/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
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

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<UserDto>> Edit(int id, [FromBody] UpdateUserDto dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var user = await _userService.UpdateAsync(id, dto);
            if (user == null) return NotFound();

            return Ok(user);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Destroy(int id)
        {
            var user = await _userService.RemoveAsync(id);
            if (!user) return NotFound();

            return NoContent();
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
