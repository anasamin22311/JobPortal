using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;

namespace JobPortal.Application.DataAccess.Services.RepositoryFactory
{
    public interface IRepositoryFactory
    {
        // returns the specific repository type based on the entity type
        IGenericRepository<T> GetRepository<T>() where T : class, new();
    }
}