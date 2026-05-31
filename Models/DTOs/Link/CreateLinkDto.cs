using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Planora.Models.DTOs.Link
{
    public class CreateLinkDto
    {
        [Required]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string Url {get;set;} = string.Empty;
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description {get;set;}
        
    }
}