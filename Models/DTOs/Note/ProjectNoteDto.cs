using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Models.DTOs.Note
{
    public class ProjectNotesDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }
    }
}