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
using AUD9001.ApplicationServices.API.Domain.Output;
using AUD9001.DataAccess.CQRS.Queries;
using AUD9001.DataAccess;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class AddOutputHandler : IRequestHandler<AddOutputRequest, AddOutputResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddOutputHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddOutputResponse> Handle(AddOutputRequest request, CancellationToken cancellationToken)
        {
            var output = this.mapper.Map<Output>(request);
            var processFromDB = await this.queryExecutor.Execute(new GetProcessQuery() { Id = request.ProcessID });
            output.Process = processFromDB;
            var command = new AddOutputCommand() { Parameter = output };
            var outputFromDb = await this.commandExecutor.Execute(command);
            return new AddOutputResponse()
            {
                Data = this.mapper.Map<Domain.Models.Output>(outputFromDb)
            };
        }
    }
}
