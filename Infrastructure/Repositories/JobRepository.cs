using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Text;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobRepository : GenericRepository<Job>, IJobRepository
    {
        private readonly AppDbContext _appDbContext;
        public JobRepository(AppDbContext appDbContext) : base(appDbContext)
        {
            _appDbContext = appDbContext ?? throw new ArgumentNullException(nameof(appDbContext));
        }

        public async Task<IEnumerable<Job>> GetJobsByCategory(string category)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(category))
                {
                    throw new ArgumentException("Category cannot be null or empty.", nameof(category));
                }

                var result = await _appDbContext.Jobs.AsNoTracking()
                .Where(j => j.Categories.Any(c => c.CategoryName == category))
                .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex, "Failed to get jobs by category");
                return new List<Job>();
            }
        }

        public async Task<IEnumerable<Job>> GetJobsByCompany(string companyName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(companyName))
                {
                    throw new ArgumentException("Company name cannot be null or empty.", nameof(companyName));
                }

                var result = await _appDbContext.Jobs.AsNoTracking()
                 .Where(j => j.Companies.Any(c => c.CompanyName == companyName))
                 .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex, "Failed to get jobs by company");
                return new List<Job>();
            }
        }

        public async Task<IEnumerable<Job>> GetJobsByEmployer(string employerName)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(employerName))
                {
                    throw new ArgumentException("Employer name cannot be null or empty.", nameof(employerName));
                }

                var result = await _appDbContext.Jobs.AsNoTracking()
                 .Where(j => j.Employer.Name == employerName)
                 .ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex, "Failed to get jobs by employer");
                return new List<Job>();
            }
        }

        public async Task<IEnumerable<Job>> GetJobsByCountry(string country)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(country))
                {
                    throw new ArgumentException("Country cannot be null or empty.", nameof(country));
                }

                var result = await _appDbContext.Jobs.AsNoTracking().Where(j => j.Location.Country == country).ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                LogError(ex, "Failed to get jobs by country");
                return new List<Job>();
            }
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private void LogError(Exception e, string message)
        {
            var sb = new StringBuilder();
            sb.Append(message);
            sb.Append(" Exception: ");
            sb.Append(e.Message);
            Console.WriteLine(sb.ToString());
        }

    }
}
