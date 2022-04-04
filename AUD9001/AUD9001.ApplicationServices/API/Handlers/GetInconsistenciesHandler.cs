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
    public class GetInconsistenciesHandler : IRequestHandler<GetInconsistenciesRequest, GetInconsistenciesResponse>
    {
        private readonly IRepository<Inconsistency> inconsistencyRepository;

        public GetInconsistenciesHandler(IRepository<DataAccess.Entities.Inconsistency> inconsistencyRepository)
        {
            this.inconsistencyRepository = inconsistencyRepository;
        }

        public async Task<GetInconsistenciesResponse> Handle(GetInconsistenciesRequest request, CancellationToken cancellationToken)
        {
            var inconsistencies = await this.inconsistencyRepository.GetAll();

            var domainInconsistencies = inconsistencies.Select(x => new Domain.Models.Inconsistency()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetInconsistenciesResponse()
            {
                Data = domainInconsistencies.ToList()
            };

            return response;
        }
    }
}
