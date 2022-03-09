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
    public class GetResourcesHandler : IRequestHandler<GetResourcesRequest, GetResourcesResponse>
    {
        private readonly IRepository<Resource> resourceRepository;

        public GetResourcesHandler(IRepository<DataAccess.Entities.Resource> resourceRepository)
        {
            this.resourceRepository = resourceRepository;
        }

        public Task<GetResourcesResponse> Handle(GetResourcesRequest request, CancellationToken cancellationToken)
        {
            var resources = this.resourceRepository.GetAll();

            var domainResources = resources.Select(x => new Domain.Models.Resource()
            {
                Name = x.Name
            });

            var response = new GetResourcesResponse()
            {
                Data = domainResources.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
