using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.ErrorHandling;
using AUD9001.DataAccess;
using AUD9001.DataAccess.CQRS.Queries;
using AUD9001.DataAccess.Entities;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class GetOutputsHandler : IRequestHandler<GetOutputsRequest, GetOutputsResponse>
    {
        private readonly IRepository<Output> outputRepository;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetOutputsHandler(IRepository<DataAccess.Entities.Output> outputRepository, IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.outputRepository = outputRepository;
            this.mapper = mapper;
            this.queryexecutor = queryexecutor;
        }

        public async Task<GetOutputsResponse> Handle(GetOutputsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOutputsQuery() { };
            var outputs = await this.queryexecutor.Execute(query);
            if (outputs == null)
            {
                return new GetOutputsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedOutputs = this.mapper.Map<List<Domain.Models.Output>>(outputs);
            var response = new GetOutputsResponse() { Data = mappedOutputs };
            return response;
        }
    }
}
