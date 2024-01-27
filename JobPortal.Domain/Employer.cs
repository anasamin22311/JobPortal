using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Employer:User
    {
        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string CompanyName { get; set; }

        [Required]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Please enter a valid contact number.")]

        public User User { get; set; }
        public ICollection<Job> JobListings { get; set; }
    }
}