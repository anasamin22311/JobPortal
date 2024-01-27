using AutoMapper;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Application.DataAccess.Services.RepositoryFactory;
using JobPortal.Application.DTOs;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Services.Implementations
{
    public class CategoryService : GenericService<Category, CategoryDTO>, ICategoryService
    {
        public CategoryService(IMapper mapper, IRepositoryFactory repositoryFactory) : base(mapper, repositoryFactory)
        {
        }

    }

}
