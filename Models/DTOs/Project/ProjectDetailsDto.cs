using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.Entities;
using Planora.Models.DTOs.Link;
using Planora.Models.DTOs.Task;
using Planora.Models.DTOs.Note;
using Planora.Models.DTOs.Idea;

namespace Planora.Models.DTOs.Project
{
    public class ProjectDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset? Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<ProjectIdeaDto> Ideas { get; set; } = new List<ProjectIdeaDto>();
        public ICollection<ProjectLinkDto> Links { get; set; } = new List<ProjectLinkDto>();
        public ICollection<ProjectTaskDto> Tasks { get; set; } = new List<ProjectTaskDto>();
        public ICollection<ProjectNotesDto> Notes { get; set; } = new List<ProjectNotesDto>();
    }
}