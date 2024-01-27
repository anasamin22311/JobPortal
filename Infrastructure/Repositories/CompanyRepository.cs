using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class CompanyRepository : GenericRepository<Company>,ICompanyRepository
    {
        public CompanyRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
