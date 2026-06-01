using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Web.Models.DTOs.Note
{
    public class ProjectNoteDto
    {
        public Guid Id { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTimeOffset CreatedAt { get; set; }        
    }
}