using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Models.DTOs.Idea;
using Planora.Services.Interfaces;

namespace Planora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaController(IIdeaService _service) : ControllerBase
    {
        [HttpPost("/api/projects/{projectId:guid}/ideas")]
        public async Task<ActionResult<ProjectIdeaDto>> CreateIdea(Guid projectId, [FromBody] CreateIdeaDto ideaDto)
        {
            var createdIdea = await _service.CreateIdeaAsync(projectId, ideaDto);
            return CreatedAtAction(nameof(GetIdeaById), new { id = createdIdea.Id }, createdIdea);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectIdeaDto>> GetIdeaById(Guid id)
        {
            var idea = await _service.GetIdeaByIdAsync(id);
            if (idea == null)
            {
                return NotFound();
            }
            return Ok(idea);
        }

        [HttpGet("/api/projects/{projectId:guid}/ideas")]
        public async Task<ActionResult<List<ProjectIdeaDto>>> GetAllIdeas(Guid projectId)
        {
            var ideas = await _service.GetAllIdeasAsync(projectId);
            return Ok(ideas);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteIdea(Guid id)
        {
            var result = await _service.DeleteIdeaAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectIdeaDto>> UpdateIdea(Guid id, [FromBody] UpdateIdeaDto ideaDto)
        {
            var updatedIdea = await _service.UpdateIdeaAsync(id, ideaDto);
            if (updatedIdea == null)
            {
                return NotFound();
            }
            return Ok(updatedIdea);
        }
    }
}
