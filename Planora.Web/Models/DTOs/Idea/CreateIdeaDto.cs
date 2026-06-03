using System.ComponentModel.DataAnnotations;

namespace Planora.Web.Models.DTOs.Idea
{
    public class CreateIdeaDto
    {
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
