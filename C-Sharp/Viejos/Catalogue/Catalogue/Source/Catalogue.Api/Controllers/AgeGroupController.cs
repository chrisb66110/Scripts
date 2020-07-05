using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using APIBase.Api.Controllers;
using APIBase.Common.Constants;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Bll.Blls.AgeGroupBll;
using Catalogue.Common.Dtos.AgeGroupDtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Catalogue.Api.Controllers
{
    [Authorize]
    //[ApiController]
    //[EnableCors("AllowedFromConfigured")]
    [Route("[controller]")]
    public class AgeGroupController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IAgeGroupBll _ageGroupBll;
        
        public AgeGroupController(
            ILogger<AgeGroupController> logger,
            IMapper mapper,
            IAgeGroupBll ageGroupBll)
        :base(logger)
        {
            _mapper = mapper;
            _ageGroupBll = ageGroupBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _ageGroupBll.GetAllAsync();

                var resultResponse = _mapper.Map<List<AgeGroupDto>, List<AgeGroupResponse>>(resultBll);
                
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
        public async Task<ObjectResult> GetByIdAsync(string id)
        {
            ObjectResult response;

            try
            {
                if (!string.IsNullOrEmpty(id))
                {
                    var resultBll = await _ageGroupBll.GetByIdAsync(id);

                    var resultResponse = _mapper.Map<AgeGroupDto, AgeGroupResponse>(resultBll);

                    response = CreateOkResponse(resultResponse);
                }
                else
                {
                    var messageErrors = BaseConstants.INVALID_ID;

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

        [HttpPost("Add")]
        public async Task<ObjectResult> AddAsync([FromBody] AgeGroupRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var ageGroupDto = _mapper.Map<AgeGroupRequest, AgeGroupDto>(request);

                    var resultBll = await _ageGroupBll.AddAsync(ageGroupDto);

                    var resultResponse = _mapper.Map<AgeGroupDto, AgeGroupResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] AgeGroupRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var ageGroupDto = _mapper.Map<AgeGroupRequest, AgeGroupDto>(request);

                    var resultBll = await _ageGroupBll.UpdateAsync(ageGroupDto);

                    var resultResponse = _mapper.Map<AgeGroupDto, AgeGroupResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] AgeGroupRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var ageGroupDto = _mapper.Map<AgeGroupRequest, AgeGroupDto>(request);

                    var resultBll = await _ageGroupBll.DeleteAsync(ageGroupDto);

                    var resultResponse = _mapper.Map<AgeGroupDto, AgeGroupResponse>(resultBll);

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

