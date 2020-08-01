using System.Collections.Generic;
using System.Threading.Tasks;
using APIBase.Common.AuthFunctions;
using APIBase.Dal.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NSpaceModelsDtosVar;
using NSpaceContextsVar;
using NSpaceModelsVar;

namespace NameSpaceVar
{
    public class NameClassVar : BaseLogRepository<NameContextVar, NameModelVar, long, NameModelLogVar>, NameInterfaceVar
    {
        private readonly IMapper _mapper;

        public NameClassVar(
            DbContextOptions<NameContextVar> options,
            IMapper mapper,
            ITokenFunctions tokenFunctions)
            : base(options, tokenFunctions)
        {
            _mapper = mapper;
        }

        public async Task<List<NameModelDtoVar>> GetAllAsync()
        {
            var listNameModelVar = await _GetAllAsync();

            var response = _mapper.Map<List<NameModelVar>, List<NameModelDtoVar>>(listNameModelVar);

            return response;
        }

        public async Task<NameModelDtoVar> GetByIdAsync(long id)
        {
            var nModelVarVar = await _GetByIdAsync(id);

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(nModelVarVar);

            return response;
        }

        public async Task<NameModelDtoVar> AddAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var nModelVarVar = _mapper.Map<NameModelDtoVar, NameModelVar>(nameModelDtoParamVar);

            var result = await _AddAsync(nModelVarVar);

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(result);

            return response;
        }

        public async Task<NameModelDtoVar> UpdateAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var nModelVarVar = _mapper.Map<NameModelDtoVar, NameModelVar>(nameModelDtoParamVar);

            var result = await _UpdateAsync(nModelVarVar);

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(result);

            return response;
        }

        public async Task<NameModelDtoVar> DeleteAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var nModelVarVar = _mapper.Map<NameModelDtoVar, NameModelVar>(nameModelDtoParamVar);

            var result = await _RemoveAsync(nModelVarVar);

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(result);

            return response;
        }

        public async Task<List<NameModelLogDtoVar>> GetLogsAsync()
        {
            var listNameModelLogVar = await _GetLogsAsync();

            var response = _mapper.Map<List<NameModelLogVar>, List<NameModelLogDtoVar>>(listNameModelLogVar);

            return response;
        }
    }
}