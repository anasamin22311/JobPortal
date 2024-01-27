using Application.DTOs;
using AutoMapper;
using JobPortal.Application.DataAccess.Interfaces.ServicesInterfaces;
using JobPortal.Application.DTOs;

namespace JobPortal.Application.DataAccess.Services.Implementations
{
    public class SearchService : ISearchService
    {
        private readonly ISearchRepository _searchRepository;
        private readonly IMapper _mapper;

        public SearchService(ISearchRepository searchRepository, IMapper mapper)
        {
            _searchRepository = searchRepository;
            _mapper = mapper;
        }

        public async Task<SearchResultsDTO> Search(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null)
        {
            var result = await _searchRepository.Search(searchString, jobType, location, startDate, minimumSalary);
            var resultDto = _mapper.Map<SearchResultsDTO>(result);
            return resultDto;

        }

        public async Task<IEnumerable<CompanyDTO>> SearchCompany(string searchString)
        {
            var result = await _searchRepository.SearchCompany(searchString);
            var resultDto = _mapper.Map<IEnumerable<CompanyDTO>>(result);
            return resultDto;
        }

        public async Task<IEnumerable<JobDTO>> SearchJob(string searchString, string jobType = null, string location = null, DateTime? startDate = null, decimal? minimumSalary = null)
        {
            var result = await _searchRepository.SearchJob(searchString, jobType, location, startDate, minimumSalary);
            var resultDto = _mapper.Map<IEnumerable<JobDTO>>(result);
            return resultDto;
        }

        public async Task<IEnumerable<LocationDTO>> SearchLocation(string searchString)
        {
            var result = await _searchRepository.SearchLocation(searchString);
            var resultDto = _mapper.Map<IEnumerable<LocationDTO>>(result);
            return resultDto;
        }
    }
}
