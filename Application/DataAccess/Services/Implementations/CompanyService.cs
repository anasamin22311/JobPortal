using Application.DTOs;
using AutoMapper;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Application.DataAccess.Services.RepositoryFactory;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Services.Implementations
{
    public class CompanyService : GenericService<Company, CompanyDTO>, ICompanyService
    {
        public CompanyService(IMapper mapper, IRepositoryFactory repositoryFactory) : base(mapper, repositoryFactory)
        {
        }

    }

}
