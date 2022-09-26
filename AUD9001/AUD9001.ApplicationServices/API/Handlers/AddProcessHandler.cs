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
using AUD9001.ApplicationServices.API.ErrorHandling;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class AddProcessHandler : IRequestHandler<AddProcessRequest,AddProcessResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddProcessHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddProcessResponse> Handle(AddProcessRequest request, CancellationToken cancellationToken)
        {
            var process = this.mapper.Map<Process>(request);
            var companyFromDB = await this.queryExecutor.Execute(new GetCompanyQuery() { Id = request.CompanyID });
            if (companyFromDB == null)
            {
                return new AddProcessResponse()
                {
                    Error = new ErrorModel("Nie znaleziono Company z Id: " + request.CompanyID)
                };
            }
            process.Company = companyFromDB;
            var command = new AddProcessCommand() { Parameter = process};
            var processFromDb = await this.commandExecutor.Execute(command);
            return new AddProcessResponse()
            {
                Data = this.mapper.Map<Domain.Models.Process>(processFromDb)
            };
        }
    }
}
