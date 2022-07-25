using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.CQRS.Queries;
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
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetManagementReviewsHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<GetManagementReviewsResponse> Handle(GetManagementReviewsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagementReviewsQuery() { };
            var managementReviews = await this.queryexecutor.Execute(query);
            var mappedManagementReviews = this.mapper.Map<List<Domain.Models.ManagementReview>>(managementReviews);
            var response = new GetManagementReviewsResponse() { Data = mappedManagementReviews };
            return response;
        }
    }
}
