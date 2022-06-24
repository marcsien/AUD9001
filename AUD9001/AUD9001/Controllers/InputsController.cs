using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;
using Microsoft.Extensions.Logging;
using AUD9001.ApplicationServices.API.Domain.Input;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InputsController : ApiControllerBase
    {
        public InputsController(IMediator mediator, ILogger<OutputsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Input Controller");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllInputs([FromQuery] GetInputsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{inputId}")]
        public Task<IActionResult> GetInputById([FromRoute] int inputId)
        {
            var request = new GetInputByIdRequest
            {
                InputId = inputId
            };
            return this.HandleRequest<GetInputByIdRequest, GetInputByIdResponse>(request);
        }
    }
}
