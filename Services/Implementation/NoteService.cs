using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Data;
using Planora.Models.DTOs.Note;
using Planora.Models.Entities;
using Planora.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Planora.Services.Implementation
{
    public class NoteService(AppDbContext _context) : INoteService
    {
        public async Task<ProjectNoteDto> CreateNoteAsync(Guid projectId, CreateNoteDto createNoteDto)
        {
            var projectExists = await _context.Projects.AnyAsync(x => x.Id == projectId);
            if (!projectExists)
            {
                throw new Exception("Project not found");
            }

            var note = new ProjectNote
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Content = createNoteDto.Content,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _context.ProjectNotes.Add(note);
            await _context.SaveChangesAsync();

            return new ProjectNoteDto
            {
                Id = note.Id,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            };
        }

        public async Task<bool> DeleteNoteAsync(Guid noteId)
        {
            var existingNote = await _context.ProjectNotes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (existingNote == null)
            {
                return false;
            }

            _context.ProjectNotes.Remove(existingNote);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjectNoteDto>> GetAllNotesAsync(Guid projectId)
        {
            var notes = await _context.ProjectNotes.Where(x => x.ProjectId == projectId).ToListAsync();

            return notes.Select(n => new ProjectNoteDto
            {
                Id = n.Id,
                Content = n.Content,
                CreatedAt = n.CreatedAt
            }).ToList();
        }

        public async Task<ProjectNoteDto> GetNoteByIdAsync(Guid noteId)
        {
            var note = await _context.ProjectNotes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (note == null)
            {
                throw new Exception("Note not found");
            }
            return new ProjectNoteDto
            {
                Id = note.Id,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            };
        }

        public async Task<ProjectNoteDto> UpdateNoteAsync(Guid noteId, UpdateNoteDto updateNoteDto)
        {
            var note = await _context.ProjectNotes.FirstOrDefaultAsync(x => x.Id == noteId);
            if (note == null)
            {
                throw new Exception("Note not found");
            }

            note.Content = updateNoteDto.Content;

            await _context.SaveChangesAsync();

            return new ProjectNoteDto
            {
                Id = note.Id,
                Content = note.Content,
                CreatedAt = note.CreatedAt
            };
        }
    }
}