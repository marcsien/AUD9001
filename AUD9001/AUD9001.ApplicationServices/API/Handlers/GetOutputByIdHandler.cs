using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Output;
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
    class GetOutputByIdHandler : IRequestHandler<GetOutputByIdRequest, GetOutputByIdResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetOutputByIdHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<GetOutputByIdResponse> Handle(GetOutputByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetOutputQuery()
            {
                Id = request.OutputId
            };
            var output = await this.queryexecutor.Execute(query);

            if (output == null)
            {
                return new GetOutputByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedOutput = this.mapper.Map<Domain.Models.Output>(output);
            var response = new GetOutputByIdResponse() { Data = mappedOutput };
            return response;
        }
    }
}
