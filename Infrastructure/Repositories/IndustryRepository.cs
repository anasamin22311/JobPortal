using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class IndustryRepository : GenericRepository<Industry>, IIndustryRepository
    {
        public IndustryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
