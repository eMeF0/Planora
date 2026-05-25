using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.DTOs;
using Planora.Models.DTOs.Project;

namespace Planora.Services.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDetailsDto> CreateProjectAsync(CreateProjectDto createProjectDto);
        Task<List<ProjectSummaryDto>> GetAllProjectsAsync();
        Task<ProjectDetailsDto?> GetProjectByIdAsync(Guid id);
        Task<ProjectDetailsDto?> UpdateProjectAsync(Guid id, UpdateProjectDto updateProjectDto);
        Task<bool> DeleteProjectAsync(Guid id);
    }
}