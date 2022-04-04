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
    public class GetObservationsHandler : IRequestHandler<GetObservationsRequest, GetObservationsResponse>
    {
        private readonly IRepository<Observation> observationRepository;

        public GetObservationsHandler(IRepository<DataAccess.Entities.Observation> observationRepository)
        {
            this.observationRepository = observationRepository;
        }

        public async Task<GetObservationsResponse> Handle(GetObservationsRequest request, CancellationToken cancellationToken)
        {
            var observations = await this.observationRepository.GetAll();

            var domainObservations = observations.Select(x => new Domain.Models.Observation()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetObservationsResponse()
            {
                Data = domainObservations.ToList()
            };

            return response;
        }
    }
}
