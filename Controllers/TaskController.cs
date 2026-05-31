using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Planora.Models.DTOs.Task;
using Planora.Services.Interfaces;

namespace Planora.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController(ITaskService _service) : ControllerBase
    {
        [HttpPost("/api/projects/{projectId:guid}/tasks")]
        public async Task<ActionResult<ProjectTaskDto>> CreateTask(Guid projectId, [FromBody] CreateTaskDto taskDto)
        {
            var createdTask = await _service.CreateTaskAsync(projectId,taskDto);
            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }

        [HttpGet("{id:guid}")]
        public async Task<ActionResult<ProjectTaskDto>> GetTaskById(Guid id)
        {
            var task = await _service.GetTaskByIdAsync(id);
            if (task == null)
            {
                return NotFound();
            }
            return Ok(task);
        }

        [HttpGet("/api/projects/{projectId:guid}/tasks")]
        public async Task<ActionResult<List<ProjectTaskDto>>> GetAllTasks(Guid projectId)
        {
            var tasks = await _service.GetAllTasksAsync(projectId);
            return Ok(tasks);
        }

        [HttpPut("{id:guid}")]
        public async Task<ActionResult<ProjectTaskDto>> UpdateTask(Guid id, [FromBody] UpdateTaskDto taskDto)
        {
            var updatedTask = await _service.UpdateTaskAsync(id, taskDto);
            if (updatedTask == null)
            {
                return NotFound();
            }
            return Ok(updatedTask);
        }

        [HttpDelete("{id:guid}")]
        public async Task<ActionResult> DeleteTask(Guid id)
        {
            var result = await _service.DeleteTaskAsync(id);
            if (!result)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
