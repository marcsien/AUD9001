using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class GetManagementReviewsHandler : IRequestHandler<GetManagementReviewsRequest, GetManagementReviewsResponse>
    {
        private readonly IRepository<ManagementReview> managementReviewRepository;

        public GetManagementReviewsHandler(IRepository<DataAccess.Entities.ManagementReview> managementReviewRepository)
        {
            this.managementReviewRepository = managementReviewRepository;
        }

        public Task<GetManagementReviewsResponse> Handle(GetManagementReviewsRequest request, CancellationToken cancellationToken)
        {
            var managementReviews = this.managementReviewRepository.GetAll();

            var domainManagementReviews = managementReviews.Select(x => new Domain.Models.ManagementReview()
            {
                Number = x.Number,
                Date = x.Date
            });

            var response = new GetManagementReviewsResponse()
            {
                Data = domainManagementReviews.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
