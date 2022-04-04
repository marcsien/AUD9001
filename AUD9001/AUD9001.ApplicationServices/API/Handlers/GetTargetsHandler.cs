using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUD9001.ApplicationServices.API.Domain;
using System.Threading;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class GetTargetsHandler : IRequestHandler<GetTargetsRequest, GetTargetsResponse>
    {
        private readonly IRepository<Target> targetRepository;

        public GetTargetsHandler(IRepository<DataAccess.Entities.Target> targetRepository)
        {
            this.targetRepository = targetRepository;
        }

        public async Task<GetTargetsResponse> Handle(GetTargetsRequest request, CancellationToken cancellationToken)
        {
            var targets = await this.targetRepository.GetAll();

            var domainTargets = targets.Select(x => new Domain.Models.Target()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetTargetsResponse()
            {
                Data = domainTargets.ToList()
            };

            return response;
        }
    }
}
