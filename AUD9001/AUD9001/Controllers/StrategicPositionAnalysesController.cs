using AUD9001.ApplicationServices.API.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StrategicPositionAnalysesController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public StrategicPositionAnalysesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllStrategicPositionAnalyses([FromQuery] GetStrategicPositionAnalysesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
