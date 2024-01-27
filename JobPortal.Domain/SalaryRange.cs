using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class SalaryRange:BaseEntity
    {

        [Required]
        [Range(0, 1000000, ErrorMessage = "MinimumSalary must be between 0 and 1,000,000")]
        public decimal MinimumSalary { get; set; }

        [Required]
        [Range(0, 1000000, ErrorMessage = "MaximumSalary must be between 0 and 1,000,000")]
        public decimal MaximumSalary { get; set; }

        // Navigation properties
        public ICollection<Job> Jobs { get; set; }
    }
}