using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain;
public partial class Job : BaseEntity
{

    [Required]
    public string Title { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public int LocationID { get; set; }

    public int? SalaryRangeID { get; set; }
    public int EmployerId { get; set; }

    [Required]
    public string Requirements { get; set; }

    [DataType(DataType.Date)]
    public DateTime DatePosted { get; set; }

    [DataType(DataType.Date)]
    public DateTime Deadline { get; set; }
    public JobType JobType { get; set; }

    // Navigation properties
    public Location Location { get; set; }
    public SalaryRange SalaryRange { get; set; }
    public Employer Employer { get; set; }
    public ICollection<JobApplication> JobApplications { get; set; }
    public ICollection<Category> Categories { get; set; }
    public ICollection<Skill>? Skills { get; set; }
    public ICollection<Industry> Industries { get; set; }
    public ICollection<ExperienceLevel> ExperienceLevels { get; set; }
    public ICollection<EducationLevel> EducationLevels { get; set; }
    public ICollection<Company> Companies { get; set; }
    public ICollection<Tag> Tags { get; set; }
}
