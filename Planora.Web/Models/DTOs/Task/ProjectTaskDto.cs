using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Web.Models.DTOs.Task
{
    public class ProjectTaskDto
    {
        public Guid Id {get;set;}
        public string Title {get;set;} = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset? Deadline {get;set;}
        public bool IsCompleted {get;set;}
        public DateTimeOffset CreatedAt {get;set;}       
    }
}