using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using Microsoft.Extensions.Logging;

namespace AUD9001.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ManagementReviewsController : ApiControllerBase
    {
        public ManagementReviewsController(IMediator mediator, ILogger<ManagementReviewsController> logger) : base(mediator)
        {
            logger.LogInformation("We are in Input Controller");
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllManagementReviews([FromQuery] GetManagementReviewsRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("{managementReviewId}")]
        public Task<IActionResult> GetManagementReviewById([FromRoute] int managementReviewId)
        {
            var request = new GetManagementReviewByIdRequest
            {
                ManagementReviewId = managementReviewId
            };
            return this.HandleRequest<GetManagementReviewByIdRequest, GetManagementReviewByIdResponse>(request);
        }
    }
}
