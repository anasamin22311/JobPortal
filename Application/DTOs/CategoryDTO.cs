using Application.DTOs.Common;

namespace JobPortal.Application.DTOs
{
    public class CategoryDTO : BaseEntityDTO
    {
        public string CategoryName { get; set; }
        public string Description { get; set; }
    }
}
