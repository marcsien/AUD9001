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
    public class GetProcessesHandler : IRequestHandler<GetProcessesRequest, GetProcessesResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetProcessesHandler(IMapper mapper, IQueryExecutor executor)
        {
            this.queryexecutor = executor;
            this.mapper = mapper;
        }
        public async Task<GetProcessesResponse> Handle(GetProcessesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetProcessesQuery()
            {
                Name = request.Name
            };
            var processes = await this.queryexecutor.Execute(query);
            if (processes == null)
            {
                return new GetProcessesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedProcesses = this.mapper.Map<List<Domain.Models.Process>>(processes);
            var response = new GetProcessesResponse() { Data = mappedProcesses };
            return response;
        }
    }
}
