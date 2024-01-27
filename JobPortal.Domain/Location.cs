using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Location:BaseEntity
    {

        [Required]
        public string LocationName { get; set; }



        [Required]
        [StringLength(50)]
        public string Region { get; set; }

        [Required]
        [StringLength(50)]
        public string Country { get; set; }

        // Navigation properties
        public ICollection<Job> Jobs { get; set; }
    }
}