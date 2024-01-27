using JobPortal.Application.DataAccess.Interfaces.RepositoriesInterfaces;
using JobPortal.Domain;
using JobPortal.Infrastructure.DbContext;

namespace JobPortal.Infrastructure.Repositories
{
    public class NotificationRepository : GenericRepository<Notification>, INotificationRepository
    {
        public NotificationRepository(AppDbContext appDbContext) : base(appDbContext)
        {
        }
    }
}
