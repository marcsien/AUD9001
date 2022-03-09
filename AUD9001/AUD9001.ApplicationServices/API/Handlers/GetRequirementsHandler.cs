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
    public class GetRequirementsHandler : IRequestHandler<GetRequirementsRequest, GetRequirementsResponse>
    {
        private readonly IRepository<Requirement> requirementRepository;

        public GetRequirementsHandler(IRepository<DataAccess.Entities.Requirement> requirementRepository)
        {
            this.requirementRepository = requirementRepository;
        }

        public Task<GetRequirementsResponse> Handle(GetRequirementsRequest request, CancellationToken cancellationToken)
        {
            var requirements = this.requirementRepository.GetAll();

            var domainRequirements = requirements.Select(x => new Domain.Models.Requirement()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetRequirementsResponse()
            {
                Data = domainRequirements.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
