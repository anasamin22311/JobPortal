using Application.DTOs;
using JobPortal.Domain;

namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface ICompanyService : IGenericService<Company, CompanyDTO>
    {
    }

}