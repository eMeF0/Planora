using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Planora.Models.Entities;

namespace Planora.Models.DTOs.Project
{
    public class CreateProjectDto
    {
        public Guid Id { get; set; }
        [Required]
        [StringLength(100, ErrorMessage = "Name cannot exceed 100 characters.")]
        public string Name { get; set; } = string.Empty;
        [StringLength(500, ErrorMessage = "Description cannot exceed 500 characters.")]
        public string? Description { get; set; }
        public DateTimeOffset? Deadline { get; set; }
        public ProjectStatus Status { get; set; }
    }
}