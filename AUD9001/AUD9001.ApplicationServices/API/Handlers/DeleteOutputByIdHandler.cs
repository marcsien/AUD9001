using AUD9001.ApplicationServices.API.Domain.Output;
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
using AUD9001.ApplicationServices.API.Domain;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class DeleteOutputByIdHandler : IRequestHandler<DeleteOutputByIdRequest, DeleteOutputByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public DeleteOutputByIdHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteOutputByIdResponse> Handle(DeleteOutputByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOutputQuery()
            {
                Id = request.OutputId
            };
            var output = await this.queryExecutor.Execute(query);

            if (output == null)
            {
                return new DeleteOutputByIdResponse()
                {
                    Error = new ErrorModel("Nie znaleziono Outputu z Id: " + request.OutputId)
                };
            }

            var command = new DeleteOutputCommand()
            {
                Parameter = output
            };

            var deletedoutput = await this.commandExecutor.Execute(command);

            return new DeleteOutputByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Output>(deletedoutput)
            };
        }
    }
}
