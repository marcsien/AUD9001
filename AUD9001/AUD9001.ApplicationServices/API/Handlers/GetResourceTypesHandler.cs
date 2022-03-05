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
    public class GetResourceTypesHandler : IRequestHandler<GetResourceTypesRequest, GetResourceTypesResponse>
    {
        private readonly IRepository<ResourceType> resourceTypeRepository;
        public GetResourceTypesHandler(IRepository<DataAccess.Entities.ResourceType> resourceTypeRepository)
        {
            this.resourceTypeRepository = resourceTypeRepository;
        }
        public Task<GetResourceTypesResponse> Handle(GetResourceTypesRequest request, CancellationToken cancellationToken)
        {
            var resourcetypes = this.resourceTypeRepository.GetAll();

            var domainresourcetypes = resourcetypes.Select(x => new Domain.Models.ResourceType()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetResourceTypesResponse()
            {
                Data = domainresourcetypes.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
