using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using AUD9001.ApplicationServices.API.ErrorHandling;
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
    internal class GetManagementReviewByIdHandler : IRequestHandler<GetManagementReviewByIdRequest, GetManagementReviewByIdResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetManagementReviewByIdHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public  async Task<GetManagementReviewByIdResponse> Handle(GetManagementReviewByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagementReviewQuery()
            {
                Id = request.ManagementReviewId
            };
            var managementReview = await this.queryexecutor.Execute(query);

            if (managementReview == null)
            {
                return new GetManagementReviewByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedManagementReview = this.mapper.Map<Domain.Models.ManagementReview>(managementReview);
            var response = new GetManagementReviewByIdResponse() { Data = mappedManagementReview };
            return response;
        }
    }
}
