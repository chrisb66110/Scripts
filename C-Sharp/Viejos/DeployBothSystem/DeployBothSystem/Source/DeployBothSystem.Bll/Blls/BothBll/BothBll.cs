using System.Collections.Generic;
using System.Threading.Tasks;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Dal.Repositories.BothRepository;

namespace DeployBothSystem.Bll.Blls.BothBll
{
    public class BothBll : IBothBll
    {
        private readonly IBothRepository _bothRepository;

        public BothBll(IBothRepository bothRepository)
        {
            _bothRepository = bothRepository;
        }

        public async Task<List<BothDto>> GetAllAsync()
        {
            var response = await _bothRepository.GetAllAsync();

            return response;
        }

        public async Task<BothDto> GetByIdAsync(string id)
        {
            var response = await _bothRepository.GetByIdAsync(id);

            return response;
        }

        public async Task<BothDto> AddAsync(BothDto bothDto)
        {
            var response = await _bothRepository.AddAsync(bothDto);

            return response;
        }

        public async Task<BothDto> UpdateAsync(BothDto bothDto)
        {
            var response = await _bothRepository.UpdateAsync(bothDto);

            return response;
        }

        public async Task<BothDto> DeleteAsync(BothDto bothDto)
        {
            var response = await _bothRepository.DeleteAsync(bothDto);

            return response;
        }
    }
}

