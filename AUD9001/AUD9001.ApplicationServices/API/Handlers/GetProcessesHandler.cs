using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
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
        private readonly IRepository<Process> processRepository;
        private readonly IMapper mapper;

        public GetProcessesHandler(IRepository<DataAccess.Entities.Process> processRepository, IMapper mapper)
        {
            this.processRepository = processRepository;
            this.mapper = mapper;
        }

        public async Task<GetProcessesResponse> Handle(GetProcessesRequest request, CancellationToken cancellationToken)
        {
            //var processes = await this.processRepository.GetAll();
            var mappedProcesses = this.mapper.Map<List<Domain.Models.Process>>(await this.processRepository.GetAll());

            //var domainProcesses = processes.Select(x => new Domain.Models.Process()
            //{
            //    Id = x.Id,
            //    Name = x.Name,
            //    Description = x.Description
            //});

            //var response = new GetProcessesResponse()
            //{
            //    Data = domainProcesses.ToList()
            //};

            //var response = new GetProcessesResponse() { Data = mappedProcesses };
            var response = new GetProcessesResponse() { Data = mappedProcesses };
            return response;
        }
    }
}
