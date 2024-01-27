using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;

namespace JobPortal.Domain
{
    public class system : BaseEntity
    {

        [Required]
        public string ConfigurationSettings { get; set; }

        [Required]
        public string Logs { get; set; }

        // Navigation properties
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<Notification> Notifications { get; set; }
    }

}