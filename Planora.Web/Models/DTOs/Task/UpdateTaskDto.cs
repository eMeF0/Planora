namespace Planora.Web.Models.DTOs.Task
{
    public class UpdateTaskDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset? Deadline { get; set; }
        public bool IsCompleted { get; set; }
    }
}
