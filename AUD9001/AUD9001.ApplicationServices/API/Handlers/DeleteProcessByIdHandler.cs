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
    public class DeleteProcessByIdHandler : IRequestHandler<DeleteProcessByIdRequest, DeleteProcessByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public DeleteProcessByIdHandler(ICommandExecutor commandexecutor, IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.commandExecutor = commandexecutor;
            this.mapper = mapper;
            this.queryExecutor = queryexecutor;
        }

        public async Task<DeleteProcessByIdResponse> Handle(DeleteProcessByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProcessQuery()
            {
                Id = request.ProcessId
            };
            var process = await this.queryExecutor.Execute(query);

            var command = new DeleteProcessCommand() 
            { 
                Parameter = process 
            };

            var deletedprocess = await this.commandExecutor.Execute(command);

            return new DeleteProcessByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Process>(deletedprocess)
            };
        }
    }
}
