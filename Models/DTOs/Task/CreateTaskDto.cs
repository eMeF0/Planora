using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Planora.Models.DTOs.Task
{
    public class CreateTaskDto
    {
        [Required]
        [StringLength(100, ErrorMessage = "Title cannot exceed 100 characters.")]
        public string Title {get;set;} = string.Empty;
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description {get;set;}
        public DateTimeOffset? Deadline {get;set;}
        //public bool IsCompleted {get;set;}
    }
}