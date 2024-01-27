using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class User : IdentityUser
    {
        [Required]
        public Role Role { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }
        [Required]
        [StringLength(15, MinimumLength = 9, ErrorMessage = "Please enter a valid contact number.")]
        public string Contact { get; set; }

        public string Password { get; set; } = string.Empty;


        // Navigation properties
        public ICollection<JobApplication> JobApplicationsAsCandidate { get; set; }
        public ICollection<JobApplication> JobApplicationsAsEmployer { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Skill> Skills { get; set; }
        public ICollection<Notification> Notifications { get; set; }
        public int? EmployerId { get; set; }
        public Employer Employer { get; set; }
    }
}
