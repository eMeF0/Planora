using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Planora.Data;
using Planora.Models.DTOs.Link;
using Planora.Models.Entities;

namespace Planora.Services
{
    public class LinkService(AppDbContext _context) : ILinkService
    {
        
        public async Task<ProjectLinkDto> CreateLinkAsync(Guid projectId, CreateLinkDto createLinkDto)
        {
            var projectExists = await _context.Projects.AnyAsync(x => x.Id == projectId);
            if (!projectExists)
            {
                throw new Exception("Project not found");
            }

            var link = new ProjectLink
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Url = createLinkDto.Url,
                Description = createLinkDto.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };

            await _context.ProjectLinks.AddAsync(link);
            await _context.SaveChangesAsync();

            return new ProjectLinkDto
            {
                Id = link.Id,
                Url = link.Url,
                Description = link.Description,
                CreatedAt = link.CreatedAt
            };


        }

        public async Task<bool> DeleteLinkAsync(Guid id)
        {
            var existingLink = await _context.ProjectLinks.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingLink == null)
            {
                return false;
            }
            _context.ProjectLinks.Remove(existingLink);

            await _context.SaveChangesAsync();

            return true;

        }

        public async Task<List<ProjectLinkDto>> GetAllLinksAsync(Guid projectId)
        {
            var links = await _context.ProjectLinks.Where(x => x.ProjectId == projectId).ToListAsync();

            return links.Select(link => new ProjectLinkDto
            {
                Id = link.Id,
                Url = link.Url,
                Description = link.Description,
                CreatedAt = link.CreatedAt
            }).ToList();
        }

        public async Task<ProjectLinkDto> GetLinkByIdAsync(Guid id)
        {
            var link = await _context.ProjectLinks.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (link == null)
            {
                throw new Exception("Link not found");
            }
            return new ProjectLinkDto
            {
                Id = link.Id,
                Url = link.Url,
                Description = link.Description,
                CreatedAt = link.CreatedAt
            };
        }

        public async Task<ProjectLinkDto> UpdateLinkAsync(Guid id, UpdateLinkDto updateLinkDto)
        {
            var existingLink = await _context.ProjectLinks.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingLink == null)
            {
                throw new Exception("Link not found");
            }

            existingLink.Url = updateLinkDto.Url;
            existingLink.Description = updateLinkDto.Description;

            _context.ProjectLinks.Update(existingLink);
            await _context.SaveChangesAsync();

            return new ProjectLinkDto
            {
                Id = existingLink.Id,
                Url = existingLink.Url,
                Description = existingLink.Description,
                CreatedAt = existingLink.CreatedAt
            };
        }
    }
}