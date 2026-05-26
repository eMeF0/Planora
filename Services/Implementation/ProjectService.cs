using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Planora.Data;
using System.Linq;
using Planora.Models.DTOs;
using Planora.Models.DTOs.Link;
using Planora.Models.DTOs.Project;
using Planora.Models.DTOs.Task;
using Planora.Models.Entities;
using Planora.Services.Interfaces;
using Planora.Models.DTOs.Note;
using Planora.Models.DTOs.Idea;

namespace Planora.Services.Implementation
{
    public class ProjectService(AppDbContext _context) : IProjectService
    {
        public async Task<ProjectDetailsDto> CreateProjectAsync(CreateProjectDto createProjectDto)
        {
            var project = new Project
            {
                Id = Guid.NewGuid(),
                Name = createProjectDto.Name,
                Description = createProjectDto.Description,
                CreatedAt = DateTimeOffset.UtcNow,
                Deadline = createProjectDto.Deadline,
                Status = ProjectStatus.Active
            };

            _context.Projects.Add(project);
            await _context.SaveChangesAsync();

            return new ProjectDetailsDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Deadline = project.Deadline,
                Status = project.Status
            };
            
        }

        public async Task<bool> DeleteProjectAsync(Guid id)
        {
            var project = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (project == null)
            {
                return false;
            }
            _context.Projects.Remove(project);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<ProjectSummaryDto>> GetAllProjectsAsync()
        {
            var projects = await _context.Projects.ToListAsync();
            return projects.Select(project => new ProjectSummaryDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                CreatedAt = project.CreatedAt,
                Deadline = project.Deadline,
                Status = project.Status
            }).ToList();
        }

        public async Task<ProjectDetailsDto?> GetProjectByIdAsync(Guid id)
        {
            var project = await _context.Projects.Where(x => x.Id == id)
                .Include(p => p.Ideas)
                .Include(p => p.Links)
                .Include(p => p.Tasks)
                .Include(p => p.Notes)
                .FirstOrDefaultAsync();
                
            if (project == null)
            {
                throw new Exception("Project not found");
            }

            return new ProjectDetailsDto
            {
                Id = project.Id,
                Name = project.Name,
                Description = project.Description,
                Deadline = project.Deadline,
                Status = project.Status,
                Links = project.Links.Select(link => new ProjectLinkDto
                {
                    Id = link.Id,
                    Url = link.Url,
                    Description = link.Description,
                    CreatedAt = link.CreatedAt
                }).ToList(),
                Tasks = project.Tasks.Select(task => new ProjectTaskDto
                {
                    Id = task.Id,
                    Title = task.Title,
                    Description = task.Description,
                    CreatedAt = task.CreatedAt
                }).ToList(),
                Notes = project.Notes.Select(note => new ProjectNoteDto
                {
                    Id = note.Id,
                    Content = note.Content,
                    CreatedAt = note.CreatedAt
                }).ToList(),
                Ideas = project.Ideas.Select(idea => new ProjectIdeaDto
                {
                    Id = idea.Id,
                    Title = idea.Title,
                    Description = idea.Description,
                    CreatedAt = idea.CreatedAt
                }).ToList()
            };
        }

        public async Task<ProjectDetailsDto?> UpdateProjectAsync(Guid id, UpdateProjectDto updateProjectDto)
        {
            var existingProject = await _context.Projects.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (existingProject == null)
            {
                throw new Exception("Project not found");
            }

            existingProject.Name = updateProjectDto.Name;
            existingProject.Description = updateProjectDto.Description;
            existingProject.Deadline = updateProjectDto.Deadline;
            existingProject.Status = updateProjectDto.Status;
            existingProject.UpdatedAt = DateTimeOffset.UtcNow;

            _context.Projects.Update(existingProject);

            await _context.SaveChangesAsync();

            return new ProjectDetailsDto
            {
                Id = existingProject.Id,
                Name = existingProject.Name,
                Description = existingProject.Description,
                Deadline = existingProject.Deadline,
                Status = existingProject.Status
            };
        }
    }
}