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

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class AddProcessHandler : IRequestHandler<AddProcessRequest,AddProcessResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddProcessHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddProcessResponse> Handle(AddProcessRequest request, CancellationToken cancellationToken)
        {
            var process = this.mapper.Map<Process>(request);
            var command = new AddProcessCommand() { Parameter = process};
            var processFromDb = await this.commandExecutor.Execute(command);
            return new AddProcessResponse()
            {
                Data = this.mapper.Map<Domain.Models.Process>(processFromDb)
            };
        }
    }
}
