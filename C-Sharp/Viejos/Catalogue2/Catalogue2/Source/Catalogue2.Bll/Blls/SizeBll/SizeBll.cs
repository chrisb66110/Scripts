using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.SizeDtos;
using Catalogue2.Dal.Repositories.SizeRepository;

namespace Catalogue2.Bll.Blls.SizeBll
{
    public class SizeBll : ISizeBll
    {
        private readonly ISizeRepository _sizeRepository;

        public SizeBll(ISizeRepository sizeRepository)
        {
            _sizeRepository = sizeRepository;
        }

        public async Task<List<SizeDto>> GetAllAsync()
        {
            var response = await _sizeRepository.GetAllAsync();

            return response;
        }

        public async Task<SizeDto> GetByIdAsync(long id)
        {
            var response = await _sizeRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<SizeDto> AddAsync(SizeDto sizeDto)
        {
            var response = await _sizeRepository.AddAsync(sizeDto);

            return response;
        }

        public async Task<SizeDto> UpdateAsync(SizeDto sizeDto)
        {
            var response = await _sizeRepository.UpdateAsync(sizeDto);

            return response;
        }

        public async Task<SizeDto> DeleteAsync(SizeDto sizeDto)
        {
            var response = await _sizeRepository.DeleteAsync(sizeDto);

            return response;
        }
    }
}

