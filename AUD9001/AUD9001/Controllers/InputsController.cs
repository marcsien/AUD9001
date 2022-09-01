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
using Microsoft.AspNetCore.Authorization;

namespace AUD9001.Controllers
{
    //[Authorize(Roles = "Manager, Administrator")]
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
        public Task<IActionResult> GetAllInputs([FromQuery] GetInputsRequest request)
        {
            return this.HandleRequest<GetInputsRequest, GetInputsResponse>(request);
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

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddInput([FromBody] AddInputRequest request)
        {
            return this.HandleRequest<AddInputRequest, AddInputResponse>(request);
        }

        [HttpPut]
        public Task<IActionResult> UpdateInput([FromBody] UpdateInputRequest request)
        {

            return this.HandleRequest<UpdateInputRequest, UpdateInputResponse>(request);
        }

        [HttpDelete]
        public Task<IActionResult> DeleteInput([FromBody] DeleteInputByIdRequest request)
        {
            return this.HandleRequest<DeleteInputByIdRequest, DeleteInputByIdResponse>(request);
        }
    }
}
