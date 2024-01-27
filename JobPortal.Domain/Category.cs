using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class Category : BaseEntity
    {
        [Required]
        public string CategoryName { get; set; }
        public string Description { get; set; }
        // Navigation properties
        public ICollection<Job> Jobs { get; set; }
    }
}