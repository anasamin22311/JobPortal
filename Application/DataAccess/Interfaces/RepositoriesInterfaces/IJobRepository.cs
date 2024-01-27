using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces
{
    public interface IJobRepository : IGenericRepository<Job>
    {
        //Task<IEnumerable<Job>> GetJobsByName(string name);
        Task<IEnumerable<Job>> GetJobsByCategory(string category);
        Task<IEnumerable<Job>> GetJobsByCompany(string companyName);
        Task<IEnumerable<Job>> GetJobsByEmployer(string employerName);
        Task<IEnumerable<Job>> GetJobsByCountry(string country);
        //Task<IEnumerable<Job>> GetJobsBySkill(string skill);
        //Task<IEnumerable<Job>> GetJobsBySalaryRange(int minSalary, int maxSalary);
        //Task<IEnumerable<Job>> GetJobsByIndustry(string industryName);
        //Task<IEnumerable<Job>> GetJobsByExperienceLevel(string experienceLevel);
        //Task<IEnumerable<Job>> GetJobsByEducationLevel(string educationLevel);
        //Task<IEnumerable<Job>> GetEmployersByLocation(string location);


    }
}
