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
    public class GetInterestedPersonsHandler : IRequestHandler<GetInterestedPersonsRequest, GetInterestedPersonsResponse>
    {
        private readonly IRepository<InterestedPerson> interestedPersonRepository;

        public GetInterestedPersonsHandler(IRepository<DataAccess.Entities.InterestedPerson> interestedPersonRepository)
        {
            this.interestedPersonRepository = interestedPersonRepository;
        }

        public async Task<GetInterestedPersonsResponse> Handle(GetInterestedPersonsRequest request, CancellationToken cancellationToken)
        {
            var interestedPersons = await this.interestedPersonRepository.GetAll();

            var domainInterestedPersons = interestedPersons.Select(x => new Domain.Models.InterestedPerson()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetInterestedPersonsResponse()
            {
                Data = domainInterestedPersons.ToList()
            };

            return response;
        }
    }
}
