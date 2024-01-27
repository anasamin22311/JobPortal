namespace JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces
{
    public interface IGenericService<T, TDto>
        where T : class, new() where TDto : class, new()
    {
        Task<TDto> Get(int id);
        Task<List<TDto>> GetAll();
        Task<TDto> Add(TDto entity);
        Task<TDto> Update(TDto entity);
        Task<TDto> Delete(TDto entity);
    }

}
