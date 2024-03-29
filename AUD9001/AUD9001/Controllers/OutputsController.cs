﻿using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;
using Microsoft.Extensions.Logging;
using AUD9001.ApplicationServices.API.Domain.Output;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OutputsController : ApiControllerBase
    {
        public OutputsController(IMediator mediator, ILogger<OutputsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Output Controller");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllOutputs([FromQuery] GetOutputsRequest request)
        {
            return  await this.HandleRequest<GetOutputsRequest, GetOutputsResponse>(request);
        }

        [HttpGet]
        [Route("{outputId}")]
        public Task<IActionResult> GetOutputById([FromRoute] int outputId)
        {
            var request = new GetOutputByIdRequest
            {
                OutputId = outputId
            };
            return this.HandleRequest<GetOutputByIdRequest, GetOutputByIdResponse>(request);
        }

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddOutput([FromBody] AddOutputRequest request)
        {
            return this.HandleRequest<AddOutputRequest, AddOutputResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> UpdateOutput([FromQuery] UpdateOutputRequest request)
        {
            return this.HandleRequest<UpdateOutputRequest, UpdateOutputResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteOutput([FromBody] DeleteOutputByIdRequest request)
        {
            return this.HandleRequest<DeleteOutputByIdRequest, DeleteOutputByIdResponse>(request);
        }
    }
}
