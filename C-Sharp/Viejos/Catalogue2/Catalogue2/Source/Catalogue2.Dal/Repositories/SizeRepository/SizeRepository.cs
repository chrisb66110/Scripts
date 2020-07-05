using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using Catalogue2.Common.Dtos.SizeDtos;
using Catalogue2.Dal.Contexts;
using Catalogue2.Dal.Models;

namespace Catalogue2.Dal.Repositories.SizeRepository
{
    public class SizeRepository : BaseRepository<Size, long>, ISizeRepository
    {
        private readonly IMapper _mapper;

        public SizeRepository(Catalogue2Context context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<SizeDto>> GetAllAsync()
        {
            var listSize = await _GetAllAsync();
            
            var response = _mapper.Map<List<Size>, List<SizeDto>>(listSize);
            return response;
        }

        public async Task<SizeDto> GetByIdAsync(long id)
        {
            var size = await _GetByIdAsync(id);

            var response = _mapper.Map<Size, SizeDto>(size);
            return response;
        }

        public async Task<SizeDto> AddAsync(SizeDto sizeDto)
        {
            var size = _mapper.Map<SizeDto, Size>(sizeDto);

            var result = await _AddAsync(size);

            var response = _mapper.Map<Size, SizeDto>(result);
            return response;
        }

        public async Task<SizeDto> UpdateAsync(SizeDto sizeDto)
        {
            var size = _mapper.Map<SizeDto, Size>(sizeDto);

            var result = await _UpdateAsync(size);

            var response = _mapper.Map<Size, SizeDto>(result);
            return response;
        }

        public async Task<SizeDto> DeleteAsync(SizeDto sizeDto)
        {
            var size = _mapper.Map<SizeDto, Size>(sizeDto);

            var result = await _RemoveAsync(size);

            var response = _mapper.Map<Size, SizeDto>(result);
            return response;
        }
    }
}

