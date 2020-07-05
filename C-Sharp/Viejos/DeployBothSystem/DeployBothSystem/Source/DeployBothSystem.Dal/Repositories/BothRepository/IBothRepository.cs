using System.Collections.Generic;
using System.Threading.Tasks;
using DeployBothSystem.Common.Dtos.BothDtos;

namespace DeployBothSystem.Dal.Repositories.BothRepository
{
    public interface IBothRepository
    {
        Task<List<BothDto>> GetAllAsync();
        Task<BothDto> GetByIdAsync(string id);
        Task<BothDto> AddAsync(BothDto bothDto);
        Task<BothDto> UpdateAsync(BothDto bothDto);
        Task<BothDto> DeleteAsync(BothDto bothDto);
    }
}

