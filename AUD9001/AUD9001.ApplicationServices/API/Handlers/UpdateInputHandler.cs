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
using AUD9001.ApplicationServices.API.Domain.Input;

namespace AUD9001.ApplicationServices.API.Handlers
{
    internal class UpdateInputHandler : IRequestHandler<UpdateInputRequest, UpdateInputResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateInputHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateInputResponse> Handle(UpdateInputRequest request, CancellationToken cancellationToken)
        {
            var command = new UpdateInputCommand()
            {
                Parameter = mapper.Map<Input>(request)
            };

            if (request.ProcessID != null)
            {
                var processcommand = new GetProcessQuery() { Id = (int)request.ProcessID };
                var process = await this.queryExecutor.Execute(processcommand);
                command.Parameter.Process = process;
            }

            var updatedinput = await this.commandExecutor.Execute(command);

            return new UpdateInputResponse()
            {
                Data = this.mapper.Map<Domain.Models.Input>(updatedinput)
            };
        }
    }
}
