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
using Catalogue.Bll.Blls.ColorBll;
using Catalogue.Common.Dtos.ColorDtos;

namespace Catalogue.Api.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class ColorController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IColorBll _colorBll;
        
        public ColorController(
            ILogger<ColorController> logger,
            IMapper mapper,
            IColorBll colorBll)
        :base(logger)
        {
            _mapper = mapper;
            _colorBll = colorBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _colorBll.GetAllAsync();

                var resultResponse = _mapper.Map<List<ColorDto>, List<ColorResponse>>(resultBll);
                
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
                var resultBll = await _colorBll.GetByIdAsync(id);

                var resultResponse = _mapper.Map<ColorDto, ColorResponse>(resultBll);

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
        public async Task<ObjectResult> AddAsync([FromBody] ColorRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var colorDto = _mapper.Map<ColorRequest, ColorDto>(request);

                    var resultBll = await _colorBll.AddAsync(colorDto);

                    var resultResponse = _mapper.Map<ColorDto, ColorResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] ColorRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var colorDto = _mapper.Map<ColorRequest, ColorDto>(request);

                    var resultBll = await _colorBll.UpdateAsync(colorDto);

                    var resultResponse = _mapper.Map<ColorDto, ColorResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] ColorRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var colorDto = _mapper.Map<ColorRequest, ColorDto>(request);

                    var resultBll = await _colorBll.DeleteAsync(colorDto);

                    var resultResponse = _mapper.Map<ColorDto, ColorResponse>(resultBll);

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

