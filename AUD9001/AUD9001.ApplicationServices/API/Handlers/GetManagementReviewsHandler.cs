using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;
using AutoMapper;
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
        private readonly IMapper mapper;

        public GetManagementReviewsHandler(IRepository<DataAccess.Entities.ManagementReview> managementReviewRepository, IMapper mapper)
        {
            this.managementReviewRepository = managementReviewRepository;
            this.mapper = mapper;
        }

        public Task<GetManagementReviewsResponse> Handle(GetManagementReviewsRequest request, CancellationToken cancellationToken)
        {
            var mappedManagementReviews = this.mapper.Map<List<Domain.Models.ManagementReview>>(this.managementReviewRepository.GetAll());
            return Task.FromResult(new GetManagementReviewsResponse() { Data = mappedManagementReviews });
        }
    }
}
