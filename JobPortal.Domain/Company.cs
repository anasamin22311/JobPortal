using JobPortal.Domain;
using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace JobPortal.Domain
{

    public class Company:BaseEntity
    {

        [Required]
        public string CompanyName { get; set; }

        [Required]
        public int IndustryID { get; set; }

        [Required]
        public int LocationID { get; set; }

        [Required]
        public int Size { get; set; }

        public string Description { get; set; }

        // Navigation properties
        public Industry Industry { get; set; }
        public Location Location { get; set; }
        public ICollection<Employer> Employers { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}