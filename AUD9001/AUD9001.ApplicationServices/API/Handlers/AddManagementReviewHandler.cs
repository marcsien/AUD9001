using AUD9001.ApplicationServices.API.Domain.ManagementReview;
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
using AUD9001.DataAccess;
using AUD9001.DataAccess.CQRS.Queries;

namespace AUD9001.ApplicationServices.API.Handlers
{
    internal class AddManagementReviewHandler : IRequestHandler<AddManagementReviewRequest, AddManagementReviewResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddManagementReviewHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddManagementReviewResponse> Handle(AddManagementReviewRequest request, CancellationToken cancellationToken)
        {
            var managementReview = this.mapper.Map<ManagementReview>(request);
            var companyFromDB = await this.queryExecutor.Execute(new GetCompanyQuery() { Id = request.CompanyID });
            if (companyFromDB == null)
            {
                return new AddManagementReviewResponse()
                {
                    Error = new ErrorModel("Nie znaleziono Company z Id: " + request.CompanyID)
                };
            }
            managementReview.Company = companyFromDB;
            var command = new AddManagementReviewCommand() { Parameter = managementReview };
            var managementReviewFromDb = await this.commandExecutor.Execute(command);
            return new AddManagementReviewResponse()
            {
                Data = this.mapper.Map<Domain.Models.ManagementReview>(managementReviewFromDb)
            };
        }
    }
}
