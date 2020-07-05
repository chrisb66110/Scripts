using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Dal.Repositories;
using AutoMapper;
using DeployBothSystem.Common.Dtos.BothDtos;
using DeployBothSystem.Dal.Contexts;
using DeployBothSystem.Dal.Models;

namespace DeployBothSystem.Dal.Repositories.BothRepository
{
    public class BothRepository : BaseRepository<Both, string>, IBothRepository
    {
        private readonly IMapper _mapper;

        public BothRepository(DeployBothSystemContext context, IMapper mapper) : base(context)
        {
            _mapper = mapper;
        }

        public async Task<List<BothDto>> GetAllAsync()
        {
            var listBoth = await _GetAllAsync();
            
            var response = _mapper.Map<List<Both>, List<BothDto>>(listBoth);
            return response;
        }

        public async Task<BothDto> GetByIdAsync(string id)
        {
            var both = await _GetByIdAsync(id);

            var response = _mapper.Map<Both, BothDto>(both);
            return response;
        }

        public async Task<BothDto> AddAsync(BothDto bothDto)
        {
            var both = _mapper.Map<BothDto, Both>(bothDto);

            var result = await _AddAsync(both);

            var response = _mapper.Map<Both, BothDto>(result);
            return response;
        }

        public async Task<BothDto> UpdateAsync(BothDto bothDto)
        {
            var both = _mapper.Map<BothDto, Both>(bothDto);

            var result = await _UpdateAsync(both);

            var response = _mapper.Map<Both, BothDto>(result);
            return response;
        }

        public async Task<BothDto> DeleteAsync(BothDto bothDto)
        {
            var both = _mapper.Map<BothDto, Both>(bothDto);

            var result = await _RemoveAsync(both);

            var response = _mapper.Map<Both, BothDto>(result);
            return response;
        }
    }
}

