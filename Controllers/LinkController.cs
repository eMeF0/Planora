using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Models.DTOs.Link;
using Planora.Services;

namespace Planora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LinkController(ILinkService _service) : ControllerBase
    {
        [HttpPost("/api/projects/{projectId:guid}/links")]
        public async Task<ActionResult<ProjectLinkDto>> CreateLink(Guid projectId, [FromBody] CreateLinkDto link)
        {
            var createdLink = await _service.CreateLinkAsync(projectId, link);
            return CreatedAtAction(nameof(GetLinkById), new { id = createdLink.Id }, createdLink);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectLinkDto>> GetLinkById(Guid id)
        {
            var link = await _service.GetLinkByIdAsync(id);
            if (link == null)
            {
                return NotFound();
            }
            return Ok(link);
        }

        [HttpGet("/api/projects/{projectId:guid}/links")]
        public async Task<ActionResult<List<ProjectLinkDto>>> GetAllLinks(Guid projectId)
        {
            var links = await _service.GetAllLinksAsync(projectId);
            return Ok(links);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteLink(Guid id)
        {
            var result = await _service.DeleteLinkAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectLinkDto>> UpdateLink(Guid id, [FromBody] UpdateLinkDto link)
        {
            var updatedLink = await _service.UpdateLinkAsync(id, link);
            if (updatedLink == null)
            {
                return NotFound();
            }
            return Ok(updatedLink);
        }
    }
}
