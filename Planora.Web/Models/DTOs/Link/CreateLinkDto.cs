using System.ComponentModel.DataAnnotations;

namespace Planora.Web.Models.DTOs.Link
{
    public class CreateLinkDto
    {
        public string Url { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
