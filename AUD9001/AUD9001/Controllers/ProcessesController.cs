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
    public class ProcessesController : ControllerBase
    {
        private readonly IMediator mediator;

        public ProcessesController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllProcesses([FromQuery] GetProcessesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        // TODO below part to furhter refinement - it returns all processes
        [HttpGet]
        [Route("{processId}")]
        public async Task<IActionResult> GetProcessById([FromQuery] GetProcessesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }


        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddProcess([FromBody] AddProcessRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
