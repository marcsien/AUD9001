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
    public class GetOutputsHandler : IRequestHandler<GetOutputsRequest, GetOutputsResponse>
    {
        private readonly IRepository<Output> outputRepository;
        private readonly IMapper mapper;

        public GetOutputsHandler(IRepository<DataAccess.Entities.Output> outputRepository, IMapper mapper)
        {
            this.outputRepository = outputRepository;
            this.mapper = mapper;
        }

        public async Task<GetOutputsResponse> Handle(GetOutputsRequest request, CancellationToken cancellationToken)
        {
            var mappedOutputs = this.mapper.Map<List<Domain.Models.Output>>(await this.outputRepository.GetAll());
            var response = new GetOutputsResponse() { Data = mappedOutputs };
            return response;
        }
    }
}
