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
using Catalogue.Bll.Blls.SizeBll;
using Catalogue.Common.Dtos.SizeDtos;

namespace Catalogue.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SizeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly ISizeBll _sizeBll;
        
        public SizeController(
            ILogger<SizeController> logger,
            IMapper mapper,
            ISizeBll sizeBll)
        :base(logger)
        {
            _mapper = mapper;
            _sizeBll = sizeBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _sizeBll.GetAllAsync();

                var resultResponse = _mapper.Map<List<SizeDto>, List<SizeResponse>>(resultBll);
                
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
                    var resultBll = await _sizeBll.GetByIdAsync(id);

                    var resultResponse = _mapper.Map<SizeDto, SizeResponse>(resultBll);

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
        public async Task<ObjectResult> AddAsync([FromBody] SizeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var sizeDto = _mapper.Map<SizeRequest, SizeDto>(request);

                    var resultBll = await _sizeBll.AddAsync(sizeDto);

                    var resultResponse = _mapper.Map<SizeDto, SizeResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] SizeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var sizeDto = _mapper.Map<SizeRequest, SizeDto>(request);

                    var resultBll = await _sizeBll.UpdateAsync(sizeDto);

                    var resultResponse = _mapper.Map<SizeDto, SizeResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] SizeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var sizeDto = _mapper.Map<SizeRequest, SizeDto>(request);

                    var resultBll = await _sizeBll.DeleteAsync(sizeDto);

                    var resultResponse = _mapper.Map<SizeDto, SizeResponse>(resultBll);

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

