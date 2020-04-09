using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BLLsNSpaceVar;
using ModelsDtosNSpaceVar;

namespace NameSpaceVar
{
    [ApiController]
    [Route("[controller]")]
    public class NameClassVar : Controller
    {
        private readonly ILogger<NameClassVar> _logger;
        private readonly InterfaceBLLVar _bll;
        
        public NameClassVar(
            ILogger<NameClassVar> logger,
            InterfaceBLLVar bll)
        {
            _logger = logger;
            _bll = bll;
        }

        [HttpGet]
        public async Task<ObjectResult> Get()
        {
            var resultBll = await _bll.Get();
            var response = CreateOkResponse(resultBll);
            _logger.LogInformation("Logger Testing in NameClassVar");
            return response;
        }

        [HttpPost]
        public async Task<ObjectResult> Post(NameModelDtoVar request)
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

        public ObjectResult CreateInvalidDataResponse()
        {
            var response = new ObjectResult("Invalid Data");
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            return response;
        }
    }
}
