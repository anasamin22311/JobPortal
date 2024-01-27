using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using System.Collections.Concurrent;
using System.Reflection;

namespace JobPortal.Application.DataAccess.Services.RepositoryFactory
{
    public class RepositoryFactory : IRepositoryFactory
    {
        private readonly ConcurrentDictionary<Type, Type> _repositoryTypes;

        private readonly IServiceProvider _serviceProvider;

        public RepositoryFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            _repositoryTypes = new ConcurrentDictionary<Type, Type>();
            var repositoryInterface = typeof(IGenericRepository<>);
            var assembly = Assembly.GetExecutingAssembly();
            var repositoryTypes = assembly.GetTypes().Where(t => t.IsClass && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == repositoryInterface));
            foreach (var repositoryType in repositoryTypes)
            {
                var entityType = repositoryType.GetInterfaces().First(i => i.IsGenericType && i.GetGenericTypeDefinition() == repositoryInterface).GetGenericArguments()[0];
                _repositoryTypes.TryAdd(entityType, repositoryType);
            }
        }
        public IGenericRepository<T> GetRepository<T>() where T : class, new()
        {
            var entityType = typeof(T);

            if (_repositoryTypes.ContainsKey(entityType))
            {
                var repositoryType = _repositoryTypes[entityType];

                return (IGenericRepository<T>)_serviceProvider.GetService(repositoryType);
            }
            else
            {
                return (IGenericRepository<T>)_serviceProvider.GetService(typeof(IGenericRepository<T>));
            }
        }
    }
}