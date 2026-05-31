using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Planora.Models.DTOs.Link
{
    public class UpdateLinkDto
    {
        public string Url {get;set;} = string.Empty;
        public string? Description {get;set;}
    }
}