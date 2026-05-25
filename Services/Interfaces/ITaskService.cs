using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.DTOs.Task;

namespace Planora.Services.Interfaces
{
    public interface ITaskService
    {
        Task<List<ProjectTaskDto>> GetAllTasksAsync(Guid projectId);
        Task<ProjectTaskDto> GetTaskByIdAsync(Guid taskId);
        Task<ProjectTaskDto> CreateTaskAsync(Guid projectId, CreateTaskDto createTaskDto);
        Task<ProjectTaskDto> UpdateTaskAsync(Guid taskId, UpdateTaskDto updateTaskDto);
        Task<bool> DeleteTaskAsync(Guid taskId);
    }
}