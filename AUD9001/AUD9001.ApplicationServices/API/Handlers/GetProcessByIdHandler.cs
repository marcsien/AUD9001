using AUD9001.ApplicationServices.API.Domain;
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
    class GetProcessByIdHandler : IRequestHandler<GetProcessByIdRequest, GetProcessByIdResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetProcessByIdHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<GetProcessByIdResponse> Handle(GetProcessByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProcessQuery()
            {
                Id = request.ProcessId
            };
            var process = await this.queryexecutor.Execute(query);
            var mappedProcess = this.mapper.Map<Domain.Models.Process>(process);
            var response = new GetProcessByIdResponse() { Data = mappedProcess };
            return response;
        }
    }
}
