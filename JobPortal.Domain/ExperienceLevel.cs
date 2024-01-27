using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace JobPortal.Domain
{

    public class ExperienceLevel : BaseEntity
    {

        [Required]
        public string ExperienceLevelName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation properties
        public ICollection<Job> Jobs { get; set; }
    }
}