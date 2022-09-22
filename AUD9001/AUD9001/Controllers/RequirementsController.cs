using AUD9001.DataAccess.Entities;
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
    public class RequirementsController : ApiControllerBase
    {
        private readonly IMediator mediator;

        public RequirementsController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRequirements([FromQuery] GetRequirementsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
