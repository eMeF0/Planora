namespace Planora.Models.Entities
{
    public class Project
    {
        public Guid Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset CreatedAt {get;set;}
        public DateTimeOffset UpdatedAt {get;set;}
        public DateTimeOffset? Deadline {get;set;}
        public ProjectStatus Status {get;set;}
        
        // Relations
        public ICollection<ProjectNote> Notes {get;set;} = [];
        public ICollection<ProjectTask> Tasks {get;set;} = [];
        public ICollection<ProjectLink> Links {get;set;} = [];
        public ICollection<ProjectIdea> Ideas {get;set;} = [];
    }
}
