using Lab2.Models.Domain;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Lab2.Models.View
{
    public record EditTicketVM
    {

        public Guid Id { get; init; }

        [Display(Name = "Is Closed")]
        public bool IsClosed { get; init; }
        public Severity Severity { get; init; }

        public string Description { get; init; } = string.Empty;


        [Display(Name = "Department")]
        public Guid DepartmentId { get; init; }

        [Display(Name = "Developers")]
        public List<Guid> DevelopersIds { get; init; } = new();


    }
}

