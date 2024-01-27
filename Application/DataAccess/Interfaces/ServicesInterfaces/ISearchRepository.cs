using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface ISearchRepository
    {
        Task<SearchResults> Search(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null);
        Task<IEnumerable<Company>> SearchCompany(string searchString);
        Task<IEnumerable<Job>> SearchJob(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null);
        Task<IEnumerable<Location>> SearchLocation(string searchString);

    }
}