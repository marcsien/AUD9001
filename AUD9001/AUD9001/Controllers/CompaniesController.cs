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
using AUD9001.ApplicationServices.API.Domain.Company;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompaniesController : ApiControllerBase
    {
        public CompaniesController(IMediator mediator, ILogger<CompaniesController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Input Controller");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllCompanies([FromQuery] GetCompaniesRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{companyId}")]
        public Task<IActionResult> GetCompanyById([FromRoute] int companyId)
        {
            var request = new GetCompanyByIdRequest
            {
                CompanyId = companyId
            };
            return this.HandleRequest<GetCompanyByIdRequest, GetCompanyByIdResponse>(request);
        }

    }
}
