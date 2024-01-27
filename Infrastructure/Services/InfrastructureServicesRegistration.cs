using JobPortal.Domain.JWT;
using JobPortal.Infrastructure.DbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace JobPortal.Infrastructure.Services
{
    public static class InfrastructureServicesRegistration
    {
        public static IServiceCollection ConfigureInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            
            services.Configure<JWT>(configuration.GetSection("JWT"));
            var databaseSettings = configuration.GetSection("ConnectionStrings");

            // Get the connection string from the configuration section.
            var connectionString = databaseSettings["DefaultConnection"]
                ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found in ConnectionStrings section in appsetting.json.");

            // Configure the DbContext (AppDbContext) with the specified connection string and migrations assembly.
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionString,
                b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)),
                ServiceLifetime.Transient);
            return services;
        }
    }
}
