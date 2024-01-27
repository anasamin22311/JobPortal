using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class CategoryRepository : GenericRepository<Category>,ICategoryRepository
    {
        public CategoryRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
