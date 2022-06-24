using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Input;
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
    class GetInputByIdHandler : IRequestHandler<GetInputByIdRequest, GetInputByIdResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetInputByIdHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<GetInputByIdResponse> Handle(GetInputByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetInputQuery()
            {
                Id = request.InputId
            };
            var input = await this.queryexecutor.Execute(query);

            if (input == null)
            {
                return new GetInputByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedInput = this.mapper.Map<Domain.Models.Input>(input);
            var response = new GetInputByIdResponse() { Data = mappedInput };
            return response;
        }
    }
}
