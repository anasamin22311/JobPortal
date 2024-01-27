using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class SalaryRangeRepository : GenericRepository<SalaryRange>, ISalaryRangeRepository
    {
        public SalaryRangeRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
