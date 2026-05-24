using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.DTOs.Link;

namespace Planora.Services
{
    public interface ILinkService
    {
        Task<List<ProjectLinkDto>> GetAllLinksAsync();
        Task<ProjectLinkDto> GetLinkByIdAsync(Guid id);
        Task<ProjectLinkDto> CreateLinkAsync(Guid projectId, CreateLinkDto createLinkDto);
        Task<ProjectLinkDto> UpdateLinkAsync(Guid id, UpdateLinkDto updateLinkDto);
        Task DeleteLinkAsync(Guid id);
    }
}