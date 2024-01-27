using Application.DTOs.Common;

namespace Application.DTOs
{
    public class JobDTO : BaseEntityDTO
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int LocationID { get; set; }
        public int? SalaryRangeID { get; set; }
        public string Requirements { get; set; }
        public DateTime DatePosted { get; set; }
        public DateTime Deadline { get; set; }
    }
}
