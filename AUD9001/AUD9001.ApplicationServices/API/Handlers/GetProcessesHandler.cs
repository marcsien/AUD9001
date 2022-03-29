using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;
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
        private readonly IRepository<Process> processRepository;

        public GetProcessesHandler(IRepository<DataAccess.Entities.Process> processRepository)
        {
            this.processRepository = processRepository;
        }

        public Task<GetProcessesResponse> Handle(GetProcessesRequest request, CancellationToken cancellationToken)
        {
            var processes = this.processRepository.GetAll();

            var domainProcesses = processes.Select(x => new Domain.Models.Process()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetProcessesResponse()
            {
                Data = domainProcesses.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
