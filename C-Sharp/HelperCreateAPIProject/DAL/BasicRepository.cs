using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using NSpaceModelsDtosVar;
using NSpaceContextsVar;
using NSpaceModelsVar;

namespace NameSpaceVar
{
    public class NameClassVar : NameInterfaceVar
    {
        private readonly NameContextVar _context;
        private readonly IMapper _mapper;

        public NameClassVar(NameContextVar context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<NameModelDtoVar>> GetAllAsync()
        {
            var nModelVarVar = new NameModelVar
            {
                Id = "NameModelDtoVar",
                Property = "Property"
            };

            var listNameModelVar = new List<NameModelVar>()
            {
                nModelVarVar
            };

            //Get data from DB

            var response = _mapper.Map<List<NameModelVar>, List<NameModelDtoVar>>(listNameModelVar);
            return response;
        }

        public async Task<NameModelDtoVar> GetByIdAsync(string id)
        {
            var nModelVarVar = new NameModelVar
            {
                Id = "NameModelDtoVar",
                Property = "Property"
            };

            //Get data from DB

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(nModelVarVar);
            return response;
        }

        public async Task<NameModelDtoVar> AddAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var nModelVarVar = _mapper.Map<NameModelDtoVar, NameModelVar>(nameModelDtoParamVar);

            //Add data from DB

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(nModelVarVar);
            return response;
        }

        public async Task<NameModelDtoVar> UpdateAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var nModelVarVar = _mapper.Map<NameModelDtoVar, NameModelVar>(nameModelDtoParamVar);

            //Update data from DB

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(nModelVarVar);
            return response;
        }

        public async Task<NameModelDtoVar> DeleteAsync(NameModelDtoVar nameModelDtoParamVar)
        {
            var nModelVarVar = _mapper.Map<NameModelDtoVar, NameModelVar>(nameModelDtoParamVar);

            //Update data from DB

            var response = _mapper.Map<NameModelVar, NameModelDtoVar>(nModelVarVar);
            return response;
        }
    }
}
