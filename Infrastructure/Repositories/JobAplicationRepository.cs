using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class JobApplicationRepository : GenericRepository<JobApplication>, IJobApplicationRepository
    {
        public JobApplicationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
