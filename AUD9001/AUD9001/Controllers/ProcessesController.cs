﻿using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProcessesController : ApiControllerBase
    {
        public ProcessesController(IMediator mediator) : base(mediator)
        {
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
        public async Task<IActionResult> GetProcessById([FromRoute] int processId)
        {
            var request = new GetProcessByIdRequest
            {
                ProcessId = processId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddProcess([FromBody] AddProcessRequest request)
        {
            return this.HandleRequest<AddProcessRequest, AddProcessResponse>(request);
        }

        [HttpDelete]
        [Route("{processId}")]
        public async Task<IActionResult> DeleteProcess([FromRoute] int processId)
        {
            var request = new DeleteProcessByIdRequest
            {
                ProcessId = processId
            };
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> UpdateProcess([FromQuery] UpdateProcessRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
