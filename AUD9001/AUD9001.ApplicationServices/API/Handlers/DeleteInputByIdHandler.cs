using AUD9001.ApplicationServices.API.Domain.Input;
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
    public class DeleteInputByIdHandler : IRequestHandler<DeleteInputByIdRequest, DeleteInputByIdResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public DeleteInputByIdHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<DeleteInputByIdResponse> Handle(DeleteInputByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInputQuery()
            {
                Id = request.InputId
            };
            var input = await this.queryExecutor.Execute(query);

            var command = new DeleteInputCommand()
            {
                Parameter = input
            };

            var deletedinput = await this.commandExecutor.Execute(command);

            return new DeleteInputByIdResponse()
            {
                Data = this.mapper.Map<Domain.Models.Input>(deletedinput)
            };
        }
    }
}
