using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Authorization;
using ProjectTimeApi.Services;
using ProjectTimeApi.DTOs;

namespace ProjectTimeApi.Controllers.Api.V1
{
    [ApiController]
    // [Authorize]
    [Route("api/v1/[controller]")]
    public class ProjectsController : ControllerBase
    {
        private readonly ProjectService _projectService;

        public ProjectsController(ProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProjectDto>> Show(int id)
        {
            var project = await _projectService.GetByIdAsync(id);
            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ProjectDto>> Edit(int id, [FromBody] CreateProjectDto dto)
        {
            var project = await _projectService.UpdateAsync(id, dto);
            if (project == null) return NotFound();

            return Ok(project);
        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<int>> Destroy(int id)
        {
            var project = await _projectService.RemoveAsync(id);
            if (!project) return NotFound();

            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectDto>>> Index()
        {
            var projects = await _projectService.GetAllAsync();
            return Ok(projects);
        }

        [HttpPost]
        public async Task<ActionResult<ProjectDto>> Create([FromBody] CreateProjectDto dto)
        {
            var project = await _projectService.CreateAsync(dto);

            return CreatedAtAction(nameof(Create), new { id = project.Id }, project);
        }
    }
}
