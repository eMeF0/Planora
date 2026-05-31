using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Models.Entities
{
    public class ProjectNote
    {
        public Guid Id {get;set;}
        public string Content {get;set;} = string.Empty;
        public Project Project {get;set;} = null!; // null! mówi kompilatorowi, że jest tutal null, ale wiem co robię i nie będzie null - nie pokazuj warningów.
        public DateTimeOffset CreatedAt { get; set; }
        public Guid ProjectId {get;set;}
    }
}