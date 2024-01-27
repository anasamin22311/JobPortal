using JobPortal.Application.DTOs;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface ICategoryService : IGenericService<Category, CategoryDTO>
    {
    }

}