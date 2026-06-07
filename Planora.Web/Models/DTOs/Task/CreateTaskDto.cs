namespace Planora.Web.Models.DTOs.Task
{
    public class CreateTaskDto
    {
        public string Title {get;set;} = string.Empty;
        public string? Description {get;set;}
        public DateTimeOffset? Deadline {get;set;}
    }
}
