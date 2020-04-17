using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSpaceRequestsVar;
using NSpaceResponsesVar;
using NSpaceBLLsVar;
using NSpaceConstantsVar;
using NSpaceModelsDtosVar;

namespace NameSpaceVar
{
    [ApiController]
    [Route("[controller]")]
    public class NameClassVar : BaseController
    {
        private readonly ILogger<NameClassVar> _logger;
        private readonly IMapper _mapper;
        private readonly InterfaceBLLVar _NameBllProperty;
        
        public NameClassVar(
            ILogger<NameClassVar> logger,
            IMapper mapper,
            InterfaceBLLVar NameBllProperty)
        {
            _logger = logger;
            _mapper = mapper;
            _NameBllProperty = NameBllProperty;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _NameBllProperty.GetAllAsync();

                var resultResponse = _mapper.Map<List<NameModelDtoVar>, List<NameResponseVar>>(resultBll);
                
                response = CreateOkResponse(resultResponse);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{Constants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(Constants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ObjectResult> GetByIdAsync(string id)
        {
            var response = CreateInvalidDataResponse();

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var resultBll = await _NameBllProperty.GetByIdAsync(id);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{Constants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(Constants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpPost("Add")]
        public async Task<ObjectResult> AddAsync([FromBody] NameRequestVar request)
        {
            var response = CreateInvalidDataResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var ModelDtoPropertyVar = _mapper.Map<NameRequestVar, NameModelDtoVar>(request);

                    var resultBll = await _NameBllProperty.AddAsync(ModelDtoPropertyVar);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{Constants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(Constants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpPut("Update")]
        public async Task<ObjectResult> UpdateAsync([FromBody] NameRequestVar request)
        {
            var response = CreateInvalidDataResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var ModelDtoPropertyVar = _mapper.Map<NameRequestVar, NameModelDtoVar>(request);

                    var resultBll = await _NameBllProperty.UpdateAsync(ModelDtoPropertyVar);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{Constants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(Constants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpDelete("Delete")]
        public async Task<ObjectResult> DeleteAsync([FromBody] NameRequestVar request)
        {
            var response = CreateInvalidDataResponse();

            try
            {
                if (ModelState.IsValid)
                {
                    var ModelDtoPropertyVar = _mapper.Map<NameRequestVar, NameModelDtoVar>(request);

                    var resultBll = await _NameBllProperty.DeleteAsync(ModelDtoPropertyVar);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{Constants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(Constants.ERROR_MESSAGE);
            }

            return response;
        }
    }
}
