namespace Planora.Web.Models.DTOs.Project
{
    public class UpdateProjectDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public ProjectStatus Status { get; set; }
        public DateTimeOffset? Deadline { get; set; }
    }
}
