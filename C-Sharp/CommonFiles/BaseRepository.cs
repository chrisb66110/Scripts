using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project.BLL.BLLs;
using Project.COMMON.Dtos.ModelsDtos;
using Project.COMMON.Settings;

namespace Project.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IProjectBLL _bll;
        private readonly ProjectSettings _setting;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger,
            IProjectBLL bll,
            ProjectSettings setting)
        {
            _logger = logger;
            _bll = bll;
            _setting = setting;
        }

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var resultBll = await _bll.DataExist();
            resultBll.Username = _setting.ConnectionStrings.ProjectMicroserviceConnectionString;
            var response = CreateOkResponse(resultBll);
            return response;
        }

        [HttpPost]
        public async Task<ObjectResult> Post(BaseModelDto request)
        {
            var response = CreateInvalidDataResponse();
            if (ModelState.IsValid)
            {
                response = CreateOkResponse(request);
            }

            return response;
        }

        public ObjectResult CreateOkResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty );
            response.StatusCode = (int)HttpStatusCode.OK;
            return response;
        }

        public ObjectResult CreateCreatedResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.Created;
            return response;
        }

        public ObjectResult CreateAcceptedResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.Accepted;
            return response;
        }

        public ObjectResult CreateBadRequestResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response;
        }

        public ObjectResult CreateInvalidDataResponse()
        {
            var response = new ObjectResult("Invalid Data");
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response;
        }

        public ObjectResult CreateUnauthorizedResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.Unauthorized;
            return response;
        }

        public ObjectResult CreateForbiddenResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.Forbidden;
            return response;
        }

        public ObjectResult CreateNotFoundResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.NotFound;
            return response;
        }

        public ObjectResult CreateMethodNotAllowedResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
            return response;
        }

        public ObjectResult CreateRequestTimeoutResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.RequestTimeout;
            return response;
        }

        public ObjectResult CreateConflictResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.Conflict;
            return response;
        }

        public ObjectResult CreateBadGatewayResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.BadGateway;
            return response;
        }

        public ObjectResult CreateGatewayTimeoutResponse(object content = null)
        {
            var response = new ObjectResult(content ?? string.Empty);
            response.StatusCode = (int)HttpStatusCode.GatewayTimeout;
            return response;
        }
    }
}
