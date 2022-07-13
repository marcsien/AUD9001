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

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class UpdateProcessHandler : IRequestHandler<UpdateProcessRequest, UpdateProcessResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateProcessHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateProcessResponse> Handle(UpdateProcessRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateProcessCommand()
            {
                Parameter = mapper.Map<Process>(request)
            };

            if (request.CompanyID != null)
            {
                var companycommand = new GetCompanyQuery() { Id = (int)request.CompanyID };
                var company = await this.queryExecutor.Execute(companycommand);
                command.Parameter.Company = company;
            }

            var updatedprocess = await this.commandExecutor.Execute(command);

            return new UpdateProcessResponse()
            {
                Data = this.mapper.Map<Domain.Models.Process>(updatedprocess)
            };
        }
    }
}
