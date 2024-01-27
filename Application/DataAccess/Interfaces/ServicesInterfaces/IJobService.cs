using Application.DTOs;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface IJobService : IGenericService<Job, JobDTO>
    {
        Task<IEnumerable<JobDTO>> GetJobsByCategory(string category);
        Task<IEnumerable<JobDTO>> GetJobsByCompany(string companyName);
        Task<IEnumerable<JobDTO>> GetJobsByEmployer(string employerName);
        Task<IEnumerable<JobDTO>> GetJobsByCountry(string country);
    }

}