using Application.DTOs;

namespace JobPortal.Application.DTOs
{
    public class SearchResultsDTO
    {
        public IEnumerable<CompanyDTO> Companies { get; set; }
        public IEnumerable<JobDTO> Jobs { get; set; }
        public IEnumerable<UserDTO> Users { get; set; }
        public IEnumerable<LocationDTO> Locations { get; set; }
    }
}