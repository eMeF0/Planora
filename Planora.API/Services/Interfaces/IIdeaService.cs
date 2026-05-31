using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.DTOs.Idea;

namespace Planora.Services.Interfaces
{
    public interface IIdeaService
    {
        Task<ProjectIdeaDto> CreateIdeaAsync(Guid projectId, CreateIdeaDto createIdeaDto);
        Task<bool> DeleteIdeaAsync(Guid ideaId);
        Task<List<ProjectIdeaDto>> GetAllIdeasAsync(Guid projectId);
        Task<ProjectIdeaDto> GetIdeaByIdAsync(Guid ideaId);
        Task<ProjectIdeaDto> UpdateIdeaAsync(Guid ideaId, UpdateIdeaDto updateIdeaDto);
    }
}