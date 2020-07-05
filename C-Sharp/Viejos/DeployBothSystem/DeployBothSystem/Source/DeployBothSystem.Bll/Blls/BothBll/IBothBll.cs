using System.Collections.Generic;
using System.Threading.Tasks;
using DeployBothSystem.Common.Dtos.BothDtos;

namespace DeployBothSystem.Bll.Blls.BothBll
{
    public interface IBothBll
    {
        Task<List<BothDto>> GetAllAsync();
        Task<BothDto> GetByIdAsync(string id);
        Task<BothDto> AddAsync(BothDto bothDto);
        Task<BothDto> UpdateAsync(BothDto bothDto);
        Task<BothDto> DeleteAsync(BothDto bothDto);
    }
}

