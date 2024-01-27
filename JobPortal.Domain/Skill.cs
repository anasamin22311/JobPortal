using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Skill:BaseEntity
    {

        [Required]
        public string SkillName { get; set; }

        [Required]
        public SkillLevel SkillLevel { get; set; }

        // Navigation properties
        public ICollection<User> Candidates { get; set; }
        public ICollection<Job> Jobs { get; set; }
    }
}