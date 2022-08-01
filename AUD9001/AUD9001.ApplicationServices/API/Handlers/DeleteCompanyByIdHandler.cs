using AUD9001.ApplicationServices.API.Domain.Company;
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
    public class DeleteCompanyByIdHandler : IRequestHandler<DeleteCompanyByIdRequest, DeleteCompanyByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public DeleteCompanyByIdHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteCompanyByIdResponse> Handle(DeleteCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompanyQuery()
            {
                Id = request.CompanyId
            };
            var company = await this.queryExecutor.Execute(query);

            var command = new DeleteCompanyCommand()
            {
                Parameter = company
            };

            var deletedcompany = await this.commandExecutor.Execute(command);

            return new DeleteCompanyByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Company>(deletedcompany)
            };
        }
    }
}
