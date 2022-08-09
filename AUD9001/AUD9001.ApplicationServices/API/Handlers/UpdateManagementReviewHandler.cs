using AUD9001.ApplicationServices.API.Domain;
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
using AUD9001.ApplicationServices.API.Domain.ManagementReview;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class UpdateManagementReviewHandler : IRequestHandler<UpdateManagementReviewRequest, UpdateManagementReviewResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateManagementReviewHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateManagementReviewResponse> Handle(UpdateManagementReviewRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateManagementReviewCommand()
            {
                Parameter = mapper.Map<ManagementReview>(request)
            };

            if (request.CompanyID != null)
            {
                var companycommand = new GetCompanyQuery() { Id = (int)request.CompanyID };
                var company = await this.queryExecutor.Execute(companycommand);
                command.Parameter.Company = company;
            }

            var updatedmanagementreview = await this.commandExecutor.Execute(command);

            return new UpdateManagementReviewResponse()
            {
                Data = this.mapper.Map<Domain.Models.ManagementReview>(updatedmanagementreview)
            };
        }
    }
}
