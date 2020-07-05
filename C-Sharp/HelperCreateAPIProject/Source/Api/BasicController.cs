using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Api.Controllers;
using APIBase.Common.Constants;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NSpaceRequestsVar;
using NSpaceResponsesVar;
using NSpaceBLLsVar;
using NSpaceModelsDtosVar;

namespace NameSpaceVar
{
    [Authorize]
    [Route("[controller]")]
    public class NameClassVar : BaseController
    {
        private readonly IMapper _mapper;
        private readonly InterfaceBLLVar _NameBllProperty;
        
        public NameClassVar(
            ILogger<NameClassVar> logger,
            IMapper mapper,
            InterfaceBLLVar NameBllProperty)
        :base(logger)
        {
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
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpGet("GetById/{id}")]
        public async Task<ObjectResult> GetByIdAsync(long id)
        {
            ObjectResult response;

            try
            {
                var resultBll = await _NameBllProperty.GetByIdAsync(id);

                var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                response = CreateOkResponse(resultResponse);
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpPost("Add")]
        public async Task<ObjectResult> AddAsync([FromBody] NameRequestVar request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var ModelDtoPropertyVar = _mapper.Map<NameRequestVar, NameModelDtoVar>(request);

                    var resultBll = await _NameBllProperty.AddAsync(ModelDtoPropertyVar);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);

                    var messageErrors = string.Join("\n", errors);

                    response = CreateInvalidDataResponse(messageErrors);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpPut("Update")]
        public async Task<ObjectResult> UpdateAsync([FromBody] NameRequestVar request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var ModelDtoPropertyVar = _mapper.Map<NameRequestVar, NameModelDtoVar>(request);

                    var resultBll = await _NameBllProperty.UpdateAsync(ModelDtoPropertyVar);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);

                    var messageErrors = string.Join("\n", errors);

                    response = CreateInvalidDataResponse(messageErrors);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }

        [HttpDelete("Delete")]
        public async Task<ObjectResult> DeleteAsync([FromBody] NameRequestVar request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var ModelDtoPropertyVar = _mapper.Map<NameRequestVar, NameModelDtoVar>(request);

                    var resultBll = await _NameBllProperty.DeleteAsync(ModelDtoPropertyVar);

                    var resultResponse = _mapper.Map<NameModelDtoVar, NameResponseVar>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
                else
                {
                    var errors = ModelState.Values.SelectMany(v => v.Errors)
                        .Select(e => e.ErrorMessage);

                    var messageErrors = string.Join("\n", errors);

                    response = CreateInvalidDataResponse(messageErrors);
                }
            }
            catch (Exception ex)
            {
                var errorMessage = $"{BaseConstants.ERROR_MESSAGE} Exception = {ex}";
                _logger.LogError(errorMessage);

                response = CreateInternalServerErrorResponse(BaseConstants.ERROR_MESSAGE);
            }

            return response;
        }
    }
}
