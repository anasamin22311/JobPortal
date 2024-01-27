using JobPortal.Domain.Common;
using System.ComponentModel.DataAnnotations;
namespace JobPortal.Domain
{

    public class Tag : BaseEntity
    {
        [Required]
        public string TageName { get; set; }
    public ICollection<Job>? Jobs { get; set; }
    }
}