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
using AUD9001.ApplicationServices.API.Domain.Output;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class UpdateOutputHandler : IRequestHandler<UpdateOutputRequest, UpdateOutputResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateOutputHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateOutputResponse> Handle(UpdateOutputRequest request, CancellationToken cancellationToken)
        {
            var checkquery = new GetOutputQuery()
            {
                Id = request.Id
            };
            var output = await this.queryExecutor.Execute(checkquery);

            if (output == null)
            {
                return new UpdateOutputResponse()
                {
                    Error = new ErrorModel("Nie znaleziono Outputu z Id: " + request.Id)
                };
            }

            var command = new UpdateOutputCommand()
            {
                Parameter = mapper.Map<Output>(request)
            };

            if (request.ProcessID != null)
            {
                var processcommand = new GetProcessQuery() { Id = (int)request.ProcessID };
                var process = await this.queryExecutor.Execute(processcommand);

                if (process == null)
                {
                    return new UpdateOutputResponse()
                    {
                        Error = new ErrorModel("Nie znaleziono Procesu z Id: " + request.ProcessID)
                    };
                }

                command.Parameter.Process = process;
            }

            var updatedoutput = await this.commandExecutor.Execute(command);

            return new UpdateOutputResponse()
            {
                Data = this.mapper.Map<Domain.Models.Output>(updatedoutput)
            };
        }
    }
}
