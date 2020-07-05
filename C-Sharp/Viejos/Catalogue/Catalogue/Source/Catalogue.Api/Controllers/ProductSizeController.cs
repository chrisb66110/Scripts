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
using Catalogue.Bll.Blls.ProductSizeBll;
using Catalogue.Common.Dtos.ProductSizeDtos;

namespace Catalogue.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductSizeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IProductSizeBll _productSizeBll;
        
        public ProductSizeController(
            ILogger<ProductSizeController> logger,
            IMapper mapper,
            IProductSizeBll productSizeBll)
        :base(logger)
        {
            _mapper = mapper;
            _productSizeBll = productSizeBll;
        }

        [HttpGet("GetAll")]
        public async Task<ObjectResult> GetAllAsync()
        {
            ObjectResult response;

            try
            {
                var resultBll = await _productSizeBll.GetAllAsync();

                var resultResponse = _mapper.Map<List<ProductSizeDto>, List<ProductSizeResponse>>(resultBll);
                
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
                    var resultBll = await _productSizeBll.GetByIdAsync(id);

                    var resultResponse = _mapper.Map<ProductSizeDto, ProductSizeResponse>(resultBll);

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
        public async Task<ObjectResult> AddAsync([FromBody] ProductSizeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productSizeDto = _mapper.Map<ProductSizeRequest, ProductSizeDto>(request);

                    var resultBll = await _productSizeBll.AddAsync(productSizeDto);

                    var resultResponse = _mapper.Map<ProductSizeDto, ProductSizeResponse>(resultBll);

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
        public async Task<ObjectResult> UpdateAsync([FromBody] ProductSizeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productSizeDto = _mapper.Map<ProductSizeRequest, ProductSizeDto>(request);

                    var resultBll = await _productSizeBll.UpdateAsync(productSizeDto);

                    var resultResponse = _mapper.Map<ProductSizeDto, ProductSizeResponse>(resultBll);

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
        public async Task<ObjectResult> DeleteAsync([FromBody] ProductSizeRequest request)
        {
            ObjectResult response;

            try
            {
                if (ModelState.IsValid)
                {
                    var productSizeDto = _mapper.Map<ProductSizeRequest, ProductSizeDto>(request);

                    var resultBll = await _productSizeBll.DeleteAsync(productSizeDto);

                    var resultResponse = _mapper.Map<ProductSizeDto, ProductSizeResponse>(resultBll);

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

