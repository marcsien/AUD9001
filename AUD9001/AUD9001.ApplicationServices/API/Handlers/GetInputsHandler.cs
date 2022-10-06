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
    public class GetInputsHandler : IRequestHandler<GetInputsRequest, GetInputsResponse>
    {
        private readonly IRepository<Input> inputRepository;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetInputsHandler(IRepository<DataAccess.Entities.Input> inputRepository,IMapper mapper, IQueryExecutor queryexecutor)
        {
            this.inputRepository = inputRepository;
            this.mapper = mapper;
            this.queryexecutor = queryexecutor;
        }

        public async Task<GetInputsResponse> Handle(GetInputsRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInputsQuery(){};
            var inputs = await this.queryexecutor.Execute(query);
            if (inputs == null)
            {
                return new GetInputsResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedInputs = this.mapper.Map<List<Domain.Models.Input>>(inputs);
            var response = new GetInputsResponse() { Data = mappedInputs };
            return response;
        }
    }
}
