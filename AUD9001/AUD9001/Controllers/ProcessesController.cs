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
using Microsoft.AspNetCore.Authorization;

namespace AUD9001.Controllers
{
    //[Authorize(Roles = "Manager, Administrator")]
    [ApiController]
    [Route("[controller]")]
    public class ProcessesController : ApiControllerBase
    {
        public ProcessesController(IMediator mediator, ILogger<ProcessesController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Processes Controller");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProcesses([FromQuery] GetProcessesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{processId}")]
        public Task<IActionResult> GetProcessById([FromRoute] int processId)
        {
            var request = new GetProcessByIdRequest
            {
                ProcessId = processId
            };
            return this.HandleRequest<GetProcessByIdRequest, GetProcessByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProcess([FromBody] AddProcessRequest request)
        {
            return this.HandleRequest<AddProcessRequest, AddProcessResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteProcess([FromBody]DeleteProcessByIdRequest request)
        {
            return this.HandleRequest<DeleteProcessByIdRequest, DeleteProcessByIdResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> UpdateProcess([FromQuery] UpdateProcessRequest request)
        {
            //var response = await this.mediator.Send(request);
            return this.HandleRequest<UpdateProcessRequest, UpdateProcessResponse>(request);//this.Ok(response);
        }
    }
}
