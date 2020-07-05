using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue2.Common.Dtos.AgeGroupDtos;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Repositories.AgeGroupRepository
{
    public class AgeGroupRepository : BaseRepository<AgeGroup, long>, IAgeGroupRepository
    {
        private readonly IMapper _mapper;

        public AgeGroupRepository(Catalogue2Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<AgeGroupDto>> GetAllAsync()
        {
            var listAgeGroup = await _GetAllAsync();
            
            var response = _mapper.Map<List<AgeGroup>, List<AgeGroupDto>>(listAgeGroup);
            return response;
        }

        public async Task<AgeGroupDto> GetByIdAsync(long id)
        {
            var ageGroup = await _GetByIdAsync(id);

            var response = _mapper.Map<AgeGroup, AgeGroupDto>(ageGroup);
            return response;
        }

        public async Task<AgeGroupDto> AddAsync(AgeGroupDto ageGroupDto)
        {
            var ageGroup = _mapper.Map<AgeGroupDto, AgeGroup>(ageGroupDto);

            var result = await _AddAsync(ageGroup);

            var response = _mapper.Map<AgeGroup, AgeGroupDto>(result);
            return response;
        }

        public async Task<AgeGroupDto> UpdateAsync(AgeGroupDto ageGroupDto)
        {
            var ageGroup = _mapper.Map<AgeGroupDto, AgeGroup>(ageGroupDto);

            var result = await _UpdateAsync(ageGroup);

            var response = _mapper.Map<AgeGroup, AgeGroupDto>(result);
            return response;
        }

        public async Task<AgeGroupDto> DeleteAsync(AgeGroupDto ageGroupDto)
        {
            var ageGroup = _mapper.Map<AgeGroupDto, AgeGroup>(ageGroupDto);

            var result = await _RemoveAsync(ageGroup);

            var response = _mapper.Map<AgeGroup, AgeGroupDto>(result);
            return response;
        }
    }
}

