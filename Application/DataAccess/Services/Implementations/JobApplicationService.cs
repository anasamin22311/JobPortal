using Application.DTOs;
using AutoMapper;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Application.DataAccess.Services.RepositoryFactory;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Services.Implementations
{
    public class JobApplicationService : GenericService<JobApplication, JobApplicationDTO>, IJobApplicationService
    {
        public JobApplicationService(IMapper mapper, IRepositoryFactory repositoryFactory) : base(mapper, repositoryFactory)
        {
        }
    }

}
