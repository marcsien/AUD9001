using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using AUD9001.DataAccess.CQRS;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess.CQRS.Commands;
using AUD9001.DataAccess.CQRS.Queries;
using AUD9001.DataAccess;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class DeleteManagementReviewByIdHandler : IRequestHandler<DeleteManagementReviewByIdRequest, DeleteManagementReviewByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public DeleteManagementReviewByIdHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public  async Task<DeleteManagementReviewByIdResponse> Handle(DeleteManagementReviewByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetManagementReviewQuery()
            {
                Id = request.ManagementReviewId
            };
            var managementReview = await this.queryExecutor.Execute(query);

            var command = new DeleteManagementReviewCommand()
            {
                Parameter = managementReview
            };

            var deletedManagementReview = await this.commandExecutor.Execute(command);

            return new DeleteManagementReviewByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.ManagementReview>(deletedManagementReview)
            };
        }
    }
}
