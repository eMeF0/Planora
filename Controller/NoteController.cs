using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Models.DTOs.Note;
using Planora.Services.Interfaces;

namespace Planora.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoteController(INoteService _service) : ControllerBase
    {
        [HttpPut]
        public async Task<ActionResult<ProjectNoteDto>> CreateNote(Guid projectId, [FromBody] CreateNoteDto noteDto)
        {
            var createdNote = await _service.CreateNoteAsync(projectId, noteDto);
            return CreatedAtAction(nameof(GetNoteById), new { id = createdNote.Id }, createdNote);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectNoteDto>> GetNoteById(Guid id)
        {
            var note = await _service.GetNoteByIdAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note);
        }

        [HttpGet("{id:guid")]
        public async Task<ActionResult<List<ProjectNoteDto>>> GetAllNotes(Guid projectId)
        {
            var notes = await _service.GetAllNotesAsync(projectId);
            return Ok(notes);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteNote(Guid id)
        {
            var result = await _service.DeleteNoteAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectNoteDto>> UpdateNote(Guid id, [FromBody] UpdateNoteDto noteDto)
        {
            var updatedNote = await _service.UpdateNoteAsync(id, noteDto);
            if (updatedNote == null)
            {
                return NotFound();
            }
            return Ok(updatedNote);
        }
    }
}
