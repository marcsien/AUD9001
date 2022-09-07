using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Company;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

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

        [HttpPost]
        [Route("")]
        public Task<IActionResult> AddCompany([FromBody] AddCompanyRequest request)
        {
            return this.HandleRequest<AddCompanyRequest, AddCompanyResponse>(request);
        }

        [HttpPut]
        [Route("")]
        public Task<IActionResult> UpdateCompany([FromQuery] UpdateCompanyRequest request)
        {
            return this.HandleRequest<UpdateCompanyRequest, UpdateCompanyResponse>(request);
        }

        [HttpDelete]
        [Route("")]
        public Task<IActionResult> DeleteProcess([FromQuery] DeleteCompanyByIdRequest request)
        {
            return this.HandleRequest<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>(request);
        }
    }
}
