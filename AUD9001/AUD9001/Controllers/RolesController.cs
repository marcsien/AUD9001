using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;
using Microsoft.AspNetCore.Authorization;

namespace AUD9001.Controllers
{
    [Authorize(Roles = "Administrator")]
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ApiControllerBase
    {
        private readonly IMediator mediator;
        public RolesController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllRoles([FromQuery] GetRolesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }
    }
}
