using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.DTOs.Note;

namespace Planora.Services.Interfaces
{
    public interface INoteService
    {
        Task<ProjectNoteDto> CreateNoteAsync(Guid projectId, CreateNoteDto createNoteDto);
        Task<bool> DeleteNoteAsync(Guid noteId);
        Task<List<ProjectNoteDto>> GetAllNotesAsync(Guid projectId);
        Task<ProjectNoteDto> GetNoteByIdAsync(Guid noteId);
        Task<ProjectNoteDto> UpdateNoteAsync(Guid noteId, UpdateNoteDto updateNoteDto);
    }
}