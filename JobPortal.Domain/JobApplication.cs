using JobPortal.Domain.Common;
using JobPortal.Models;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class JobApplication: BaseEntity
    {

        public int? CandidateID { get; set; }

        public int? EmployerID { get; set; }

        [Required]
        public int JobID { get; set; }
        [Required] 
        public int EmployerId { get;set; }

        [Required]
        public string Resume { get; set; }

        [DataType(DataType.MultilineText)]
        public string CoverLetter { get; set; }

        [Required]
        public ApplicationStatus ApplicationStatus { get; set; }

        // Navigation properties
        public User Candidate { get; set; }
        public Employer Employer { get; set; }
        public Job Job { get; set; }
    }
}
