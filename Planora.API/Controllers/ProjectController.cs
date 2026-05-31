using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Models.DTOs;
using Planora.Models.DTOs.Project;
using Planora.Services.Interfaces;

namespace Planora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController(IProjectService _service) : ControllerBase
    {
        [HttpPost]
        public async Task<ActionResult<ProjectDetailsDto>> CreateProject([FromBody] CreateProjectDto projectDto)
        {
            var createdProject = await _service.CreateProjectAsync(projectDto);
            return CreatedAtAction(nameof(GetProjectById), new { id = createdProject.Id }, createdProject);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectDetailsDto>> GetProjectById(Guid id)
        {
            var project = await _service.GetProjectByIdAsync(id);
            if (project == null)
            {
                return NotFound();
            }
            return Ok(project);
        }

        [HttpGet]
        public async Task<ActionResult<List<ProjectSummaryDto>>> GetAllProjects()
        {
            var projects = await _service.GetAllProjectsAsync();
            return Ok(projects);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectDetailsDto>> UpdateProject(Guid id, [FromBody] UpdateProjectDto projectDto)
        {
            var updatedProject = await _service.UpdateProjectAsync(id, projectDto);
            if (updatedProject == null)
            {
                return NotFound();
            }
            return Ok(updatedProject);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteProject(Guid id)
        {
            var success = await _service.DeleteProjectAsync(id);
            if (!success)
            {
                return NotFound();
            }
            return NoContent();
        }

    }
}
