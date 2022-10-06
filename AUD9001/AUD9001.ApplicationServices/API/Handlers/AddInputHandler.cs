using AUD9001.ApplicationServices.API.Domain.Input;
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
    internal class AddInputHandler : IRequestHandler<AddInputRequest, AddInputResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public AddInputHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<AddInputResponse> Handle(AddInputRequest request, CancellationToken cancellationToken)
        {
            var input = this.mapper.Map<Input>(request);
            var processFromDB = await this.queryExecutor.Execute(new GetProcessQuery() { Id = request.ProcessID });
            if (processFromDB == null)
            {
                return new AddInputResponse()
                {
                    Error = new ErrorModel("Nie znaleziono Procesu z Id: " + request.ProcessID)
                };
            }
            input.Process = processFromDB;
            var command = new AddInputCommand() { Parameter = input };
            var inputFromDb = await this.commandExecutor.Execute(command);
            return new AddInputResponse()
            {
                Data = this.mapper.Map<Domain.Models.Input>(inputFromDb)
            };
        }
    }
}
