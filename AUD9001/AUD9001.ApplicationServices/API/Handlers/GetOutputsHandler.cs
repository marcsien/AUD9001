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
    public class GetOutputsHandler : IRequestHandler<GetOutputsRequest, GetOutputsResponse>
    {
        private readonly IRepository<Output> outputRepository;

        public GetOutputsHandler(IRepository<DataAccess.Entities.Output> outputRepository)
        {
            this.outputRepository = outputRepository;
        }

        public Task<GetOutputsResponse> Handle(GetOutputsRequest request, CancellationToken cancellationToken)
        {
            var outputs = this.outputRepository.GetAll();

            var domainOutputs = outputs.Select(x => new Domain.Models.Output()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetOutputsResponse()
            {
                Data = domainOutputs.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
