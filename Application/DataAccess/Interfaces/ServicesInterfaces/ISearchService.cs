using Application.DTOs;
using JobPortal.Application.DTOs;

namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface ISearchService
    {
        Task<SearchResultsDTO> Search(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null);
        Task<IEnumerable<CompanyDTO>> SearchCompany(string searchString);
        Task<IEnumerable<JobDTO>> SearchJob(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null);
        Task<IEnumerable<LocationDTO>> SearchLocation(string searchString);
    }
}