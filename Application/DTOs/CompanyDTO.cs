using Application.DTOs.Common;

namespace Application.DTOs
{
    public class CompanyDTO : BaseEntityDTO
    {
        public string CompanyName { get; set; }
        public int IndustryID { get; set; }
        public int LocationID { get; set; }
        public int Size { get; set; }
        public string Description { get; set; }
    }
}
