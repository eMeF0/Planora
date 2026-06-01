using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Web.Models.DTOs
{
    public class ProjectSummaryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset? Deadline { get; set; }
        public ProjectStatus Status { get; set; }
    }

}