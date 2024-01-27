using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Domain;

namespace JobPortal.Infrastructure.Repositories
{
    public class SearchRepository : ISearchRepository
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IJobRepository _jobRepository;
        private readonly ILocationRepository _locationRepository;

        public SearchRepository(ICompanyRepository companyRepository, IJobRepository jobRepository, ILocationRepository locationRepository)
        {
            _companyRepository = companyRepository;
            _jobRepository = jobRepository;
            _locationRepository = locationRepository;
        }

        public async Task<SearchResults> Search(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null)
        {
            var companyTask = SearchCompany(searchString);
            var jobTask = SearchJob(searchString, jobType, location, startDate, minimumSalary);
            var locationTask = SearchLocation(searchString);

            await Task.WhenAll(companyTask, jobTask, locationTask);

            return new SearchResults
            {
                Companies = companyTask.Result,
                Jobs = jobTask.Result,
                Locations = locationTask.Result,
            };
        }

        public async Task<IEnumerable<Company>> SearchCompany(string searchString)
        {
            var lowerSearchString = searchString.ToLowerInvariant();

            return (await _companyRepository.GetAll())
                .Where(c => c.CompanyName.ToLowerInvariant().Contains(lowerSearchString))
                .ToList();
        }

        public async Task<IEnumerable<Job>> SearchJob(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null)
        {
            var query = (await _jobRepository.GetAll()).AsQueryable();

            var lowerSearchString = searchString.ToLowerInvariant();

            if (!string.IsNullOrEmpty(searchString))
            {
                query = query.Where(j => j.Title.ToLowerInvariant().Contains(lowerSearchString)
                    || j.Description.ToLowerInvariant().Contains(lowerSearchString)
                    || j.Skills.Any(s => s.SkillName.ToLowerInvariant().Contains(lowerSearchString)));
            }

            if (!string.IsNullOrEmpty(jobType))
            {
                query = query.Where(j => j.JobType.ToString() == jobType);
            }

            if (!string.IsNullOrEmpty(location))
            {
                var lowerLocation = location.ToLowerInvariant();

                query = query.Where(j => j.Location.LocationName.ToLowerInvariant().Contains(lowerLocation));
            }

            if (startDate.HasValue)
            {
                query = query.Where(j => j.DatePosted >= startDate.Value);
            }

            if (minimumSalary.HasValue)
            {
                query = query.Where(j => j.SalaryRange.MinimumSalary >= minimumSalary.Value); 
            }

            return query.ToList();
        }

        public async Task<IEnumerable<Location>> SearchLocation(string searchString)
        {
            var lowerSearchString = searchString.ToLowerInvariant();

            return (await _locationRepository.GetAll())
                .Where(l => l.Country.ToLowerInvariant().Contains(lowerSearchString))
                .ToList();
        }
    }
}

        //public async Task<IEnumerable<User>> SearchUser(string searchString)
        //{
        //    return await _userRepository.GetAllAsync()
        //        .Where(u => u.Skills.Any(s => s.SkillName.ToLowerInvariant().Contains(searchString.ToLowerInvariant())))
        //        .ToListAsync();
        //}