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
    public class TaskService(AppDbContext _context) : ITaskService
    {
        public async Task<ProjectTaskDto> CreateTaskAsync(Guid projectId, CreateTaskDto createTaskDto)
        {
            var task = new ProjectTask
            {
                Id = Guid.NewGuid(),
                ProjectId = projectId,
                Title = createTaskDto.Title,
                Description = createTaskDto.Description,
                CreatedAt = DateTimeOffset.UtcNow
            };

            _context.ProjectTasks.Add(task);
            await _context.SaveChangesAsync();
            return new ProjectTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt
            };
        }

        public async Task<bool> DeleteTaskAsync(Guid taskId)
        {
            var existingTask = await _context.ProjectTasks.Where(x => x.Id == taskId).FirstOrDefaultAsync();
            if (existingTask == null)
            {
                return false;
            }
            _context.ProjectTasks.Remove(existingTask);
            await _context.SaveChangesAsync();
            return true; 
        }

        public async Task<List<ProjectTaskDto>> GetAllTasksAsync(Guid projectId)
        {
            var tasks = await _context.ProjectTasks.Where(x => x.ProjectId == projectId).ToListAsync();
            return tasks.Select(task => new ProjectTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt
                
            }).ToList();
        }

        public async Task<ProjectTaskDto> GetTaskByIdAsync(Guid taskId)
        {
            var task = await _context.ProjectTasks.Where(x => x.Id == taskId).FirstOrDefaultAsync();
            if (task == null)
            {
                throw new InvalidOperationException("Task not found");
            }
            return new ProjectTaskDto
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                CreatedAt = task.CreatedAt
            };
        }

        public async Task<ProjectTaskDto> UpdateTaskAsync(Guid taskId, UpdateTaskDto updateTaskDto)
        {
            var existingTask = await _context.ProjectTasks.Where(x => x.Id == taskId).FirstOrDefaultAsync();
            if (existingTask == null)
            {
                throw new InvalidOperationException("Task not found");
            }

            existingTask.Title = updateTaskDto.Title;
            existingTask.Description = updateTaskDto.Description;
            existingTask.Deadline = updateTaskDto.Deadline;
            existingTask.IsCompleted = updateTaskDto.IsCompleted;

            _context.ProjectTasks.Update(existingTask);
            await _context.SaveChangesAsync();
            return new ProjectTaskDto
            {
                Id = existingTask.Id,
                Title = existingTask.Title,
                Description = existingTask.Description,
                Deadline = existingTask.Deadline,
                IsCompleted = existingTask.IsCompleted,
                CreatedAt = existingTask.CreatedAt
            };
        }
    }
}