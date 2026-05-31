using Microsoft.EntityFrameworkCore;
using Planora.Data;
using Planora.Models.DTOs.Idea;
using Planora.Models.Entities;
using Planora.Services.Interfaces;

namespace Planora.Services.Implementation
{
    public class IdeaService(AppDbContext _context) : IIdeaService
    {
        public async Task<ProjectIdeaDto> CreateIdeaAsync(Guid projectId, CreateIdeaDto createIdeaDto)
        {
            var projectExists = await _context.Projects.AnyAsync(x => x.Id == projectId);

            if (!projectExists)
            {
                throw new Exception("No project found!");
            }

            var newIdea = new ProjectIdea
            {
                Id = Guid.NewGuid(),
                Title = createIdeaDto.Title,
                Description = createIdeaDto.Description,
                CreatedAt = DateTimeOffset.UtcNow,
                ProjectId = projectId
            };

            _context.ProjectIdeas.Add(newIdea);
            await _context.SaveChangesAsync();

            return new ProjectIdeaDto
            {
                Id = newIdea.Id,
                Title = newIdea.Title,
                Description = newIdea.Description,
            };
        }

        public async Task<bool> DeleteIdeaAsync(Guid ideaId)
        {
            var existingIdea = await _context.ProjectIdeas.FirstOrDefaultAsync(x => x.Id == ideaId);

            if (existingIdea == null)
            {
                return false;
            }

            _context.ProjectIdeas.Remove(existingIdea);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjectIdeaDto>> GetAllIdeasAsync(Guid projectId)
        {
            var ideas = await _context.ProjectIdeas.Where(x => x.ProjectId == projectId).ToListAsync();
            return ideas.Select(idea => new ProjectIdeaDto
            {
                Id = idea.Id,
                Title = idea.Title,
                Description = idea.Description
            }).ToList();
        }

        public async Task<ProjectIdeaDto> GetIdeaByIdAsync(Guid ideaId)
        {
            var existingIdea = await _context.ProjectIdeas.FirstOrDefaultAsync(x => x.Id == ideaId);
            if (existingIdea == null)
            {
                throw new Exception("Idea not found!");
            }

            return new ProjectIdeaDto
            {
                Id = existingIdea.Id,
                Title = existingIdea.Title,
                Description = existingIdea.Description
            };
        }

        public async Task<ProjectIdeaDto> UpdateIdeaAsync(Guid ideaId, UpdateIdeaDto updateIdeaDto)
        {
            var existingIdea = await _context.ProjectIdeas.FirstOrDefaultAsync(x => x.Id == ideaId);
            if (existingIdea == null)
            {
                throw new Exception("Idea not found!");
            }

            existingIdea.Title = updateIdeaDto.Title;
            existingIdea.Description = updateIdeaDto.Description;

            _context.ProjectIdeas.Update(existingIdea);
            await _context.SaveChangesAsync();

            return new ProjectIdeaDto
            {
                Id = existingIdea.Id,
                Title = existingIdea.Title,
                Description = existingIdea.Description
            };
        }
    }
}
