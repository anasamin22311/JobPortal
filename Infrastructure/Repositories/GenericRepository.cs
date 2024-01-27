using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;

namespace JobPortal.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AppDbContext _appDbContext;

        public GenericRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<T> Add(T entity)
        {

            _appDbContext.Set<T>().Add(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Delete(T entity)
        {
            _appDbContext.Set<T>().Remove(entity);
            await _appDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<T> Get(int id)
        {
            var entity = await _appDbContext.Set<T>().FindAsync(id);
            return entity;
        }

        public async Task<List<T>> GetAll()
        {
            var entities = await _appDbContext.Set<T>().ToListAsync();
            return entities;
        }

        public async Task<T> Update(T entity)
        {
            _appDbContext.Set<T>().Attach(entity);
            _appDbContext.Entry(entity).State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();
            return entity;
        }
        
    }
}
