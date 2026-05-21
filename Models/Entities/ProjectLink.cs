using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Models.Entities
{
    public class ProjectLink
    {
        public Guid Id {get;set;}
        public string Url {get;set;} = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset CreatedAt { get; set; }
        public Project Project {get;set;} = null!;
        public Guid ProjectId {get;set;}
    }
}