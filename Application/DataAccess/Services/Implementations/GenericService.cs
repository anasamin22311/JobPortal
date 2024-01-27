using AutoMapper;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Application.DataAccess.Services.RepositoryFactory;

namespace JobPortal.Application.DataAccess.Services.Implementations
{
    public class GenericService<T, TDto> : IGenericService<T, TDto>
        where T : class, new() where TDto : class, new()
    {
        protected readonly IMapper _mapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public GenericService(IMapper mapper, IRepositoryFactory repositoryFactory)
        {
            _mapper = mapper;
            _repositoryFactory = repositoryFactory;
        }

        public async Task<TDto> Add(TDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var entity = _mapper.Map<T>(dto);
            await _repositoryFactory.GetRepository<T>().Add(entity);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Delete(TDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var entity = _mapper.Map<T>(dto);
            await _repositoryFactory.GetRepository<T>().Delete(entity);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<TDto> Get(int id)
        {
            var entity = await _repositoryFactory.GetRepository<T>().Get(id);
            return _mapper.Map<TDto>(entity);
        }

        public async Task<List<TDto>> GetAll()
        {
            var entities = await _repositoryFactory.GetRepository<T>().GetAll();
            return _mapper.Map<List<TDto>>(entities);

        }

        public async Task<TDto> Update(TDto dto)
        {
            ArgumentNullException.ThrowIfNull(dto);
            var entity = _mapper.Map<T>(dto);
            await _repositoryFactory.GetRepository<T>().Update(entity);
            return _mapper.Map<TDto>(entity);
        }
    }
}