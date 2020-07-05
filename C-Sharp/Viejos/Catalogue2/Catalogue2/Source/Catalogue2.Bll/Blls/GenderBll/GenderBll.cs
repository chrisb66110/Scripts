using System.Collections.Generic;
using System.Threading.Tasks;
using Catalogue2.Common.Dtos.GenderDtos;
using Catalogue2.Dal.Repositories.GenderRepository;

namespace Catalogue2.Bll.Blls.GenderBll
{
    public class GenderBll : IGenderBll
    {
        private readonly IGenderRepository _genderRepository;

        public GenderBll(IGenderRepository genderRepository)
        {
            _genderRepository = genderRepository;
        }

        public async Task<List<GenderDto>> GetAllAsync()
        {
            var response = await _genderRepository.GetAllAsync();

            return response;
        }

        public async Task<GenderDto> GetByIdAsync(long id)
        {
            var response = await _genderRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<GenderDto> AddAsync(GenderDto genderDto)
        {
            var response = await _genderRepository.AddAsync(genderDto);

            return response;
        }

        public async Task<GenderDto> UpdateAsync(GenderDto genderDto)
        {
            var response = await _genderRepository.UpdateAsync(genderDto);

            return response;
        }

        public async Task<GenderDto> DeleteAsync(GenderDto genderDto)
        {
            var response = await _genderRepository.DeleteAsync(genderDto);

            return response;
        }
    }
}

