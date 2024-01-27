using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class EducationalLevelRepository : GenericRepository<EducationLevel>, IEducationalLevelRepository
    {
        public EducationalLevelRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
