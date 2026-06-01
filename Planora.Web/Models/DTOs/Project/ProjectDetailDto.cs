using Microsoft.AspNetCore.Components;
using Planora.Web.Models.DTOs.Idea;
using Planora.Web.Models.DTOs.Link;
using Planora.Web.Models.DTOs.Note;
using Planora.Web.Models.DTOs.Task;


namespace Planora.Web.Models.DTOs.Project
{
    public class ProjectDetailDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset? Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<ProjectIdeaDto> Ideas { get; set; } = new List<ProjectIdeaDto>();
        public ICollection<ProjectLinkDto> Links { get; set; } = new List<ProjectLinkDto>();
        public ICollection<ProjectTaskDto> Tasks { get; set; } = new List<ProjectTaskDto>();
        public ICollection<ProjectNoteDto> Notes { get; set; } = new List<ProjectNoteDto>();
    }
}