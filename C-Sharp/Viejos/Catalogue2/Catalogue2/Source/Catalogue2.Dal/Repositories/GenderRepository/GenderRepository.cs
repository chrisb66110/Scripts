using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Repositories.GenderRepository
{
    public class GenderRepository : BaseRepository<Gender, long>, IGenderRepository
    {
        private readonly IMapper _mapper;

        public GenderRepository(Catalogue2Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<GenderDto>> GetAllAsync()
        {
            var listGender = await _GetAllAsync();
            
            var response = _mapper.Map<List<Gender>, List<GenderDto>>(listGender);
            return response;
        }

        public async Task<GenderDto> GetByIdAsync(long id)
        {
            var gender = await _GetByIdAsync(id);

            var response = _mapper.Map<Gender, GenderDto>(gender);
            return response;
        }

        public async Task<GenderDto> AddAsync(GenderDto genderDto)
        {
            var gender = _mapper.Map<GenderDto, Gender>(genderDto);

            var result = await _AddAsync(gender);

            var response = _mapper.Map<Gender, GenderDto>(result);
            return response;
        }

        public async Task<GenderDto> UpdateAsync(GenderDto genderDto)
        {
            var gender = _mapper.Map<GenderDto, Gender>(genderDto);

            var result = await _UpdateAsync(gender);

            var response = _mapper.Map<Gender, GenderDto>(result);
            return response;
        }

        public async Task<GenderDto> DeleteAsync(GenderDto genderDto)
        {
            var gender = _mapper.Map<GenderDto, Gender>(genderDto);

            var result = await _RemoveAsync(gender);

            var response = _mapper.Map<Gender, GenderDto>(result);
            return response;
        }
    }
}

