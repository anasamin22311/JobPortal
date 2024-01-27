using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class ExperienceLevelRepository : GenericRepository<ExperienceLevel>, IExperienceLevelRepository
    {
        public ExperienceLevelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
