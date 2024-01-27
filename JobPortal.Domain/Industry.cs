using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Industry:BaseEntity
    {

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string IndustryName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation properties
        public ICollection<Job> Jobs { get; set; }
    }
}