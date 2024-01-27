using Application.DTOs;
using AutoMapper;
using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Application.DataAccess.Services.RepositoryFactory;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Services.Implementations
{
    public class JobService : GenericService<Job, JobDTO>, IJobService
    {
        private readonly IJobRepository _jobRepository;

        public JobService(IMapper mapper, IRepositoryFactory repositoryFactory,
            IJobRepository jobRepository) : base(mapper, repositoryFactory)
        {
            _jobRepository = jobRepository;
        }

        public async Task<IEnumerable<JobDTO>> GetJobsByCategory(string category)
        {
            ArgumentNullException.ThrowIfNull(category);
            var jobs = await _jobRepository.GetJobsByCategory(category);
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }

        public async Task<IEnumerable<JobDTO>> GetJobsByCompany(string companyName)
        {
            ArgumentNullException.ThrowIfNull(companyName);
            var jobs = await _jobRepository.GetJobsByCompany(companyName);
            return _mapper.Map<IEnumerable<JobDTO>>(companyName);
        }

        public async Task<IEnumerable<JobDTO>> GetJobsByCountry(string country)
        {
            ArgumentNullException.ThrowIfNull(country);
            var jobs = await _jobRepository.GetJobsByCountry(country);
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }

        public async Task<IEnumerable<JobDTO>> GetJobsByEmployer(string employerName)
        {
            ArgumentNullException.ThrowIfNull(employerName);
            var jobs = await _jobRepository.GetJobsByEmployer(employerName);
            return _mapper.Map<IEnumerable<JobDTO>>(jobs);
        }
    }

}
