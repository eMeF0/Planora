using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.Entities;

namespace Planora.Models.DTOs.Project
{
    public class ProjectDetailsDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset Deadline { get; set; }
        public ProjectStatus Status { get; set; }
        public ICollection<ProjectIdea> Ideas { get; set; } = new List<ProjectIdea>();
        public ICollection<ProjectLink> Links { get; set; } = new List<ProjectLink>();
        public ICollection<ProjectTask> Tasks { get; set; } = new List<ProjectTask>();
    }
}