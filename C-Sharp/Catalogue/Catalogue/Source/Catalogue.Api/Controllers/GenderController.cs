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
using Catalogue.Api.Requests;
using Catalogue.Api.Responses;
using Catalogue.Bll.Blls.GenderBll;
using Catalogue.Common.Dtos.GenderDtos;

namespace Catalogue.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class GenderController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IGenderBll _genderBll;
        
        public GenderController(
            ILogger<GenderController> logger,
            IMapper mapper,
            IGenderBll genderBll)
        :base(logger)
        {
            _mapper = mapper;
            _genderBll = genderBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _genderBll.GetAllAsync();

                var resultResponse = _mapper.Map<List<GenderDto>, List<GenderResponse>>(resultBll);
                
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
                var resultBll = await _genderBll.GetByIdAsync(id);

                var resultResponse = _mapper.Map<GenderDto, GenderResponse>(resultBll);

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
        public async Task<ObjectResult> AddAsync([FromBody] GenderRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var genderDto = _mapper.Map<GenderRequest, GenderDto>(request);

                    var resultBll = await _genderBll.AddAsync(genderDto);

                    var resultResponse = _mapper.Map<GenderDto, GenderResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] GenderRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var genderDto = _mapper.Map<GenderRequest, GenderDto>(request);

                    var resultBll = await _genderBll.UpdateAsync(genderDto);

                    var resultResponse = _mapper.Map<GenderDto, GenderResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] GenderRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var genderDto = _mapper.Map<GenderRequest, GenderDto>(request);

                    var resultBll = await _genderBll.DeleteAsync(genderDto);

                    var resultResponse = _mapper.Map<GenderDto, GenderResponse>(resultBll);

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

