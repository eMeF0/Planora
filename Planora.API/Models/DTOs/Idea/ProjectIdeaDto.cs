using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Models.DTOs.Idea
{
    public class ProjectIdeaDto
    {
        public Guid Id {get;set;}
        public string Title {get;set;} = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset CreatedAt { get; set; }
    }
}