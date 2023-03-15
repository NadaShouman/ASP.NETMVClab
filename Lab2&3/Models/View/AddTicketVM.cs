﻿using Lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2.Models.View
{
    public record AddTicketVM
    {
        
        [Display(Name = "Is Closed")]
        public bool IsClosed { get; set; }
        public Severity Severity { get; set; }

        public string Description { get; set; } = string.Empty;


        [Display(Name = "Department")]
        public Guid DepartmentId { get; init; }

        [Display(Name = "Developers")]
        public List<Guid> DevelopersIds { get; init; } = new();


    }
}
