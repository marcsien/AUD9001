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
    public class GetAcceptanceCriteriasHandler : IRequestHandler<GetAcceptanceCriteriasRequest, GetAcceptanceCriteriasResponse>
    {
        private readonly IRepository<AcceptanceCriteria> acceptnceCriteriasRepository;

        public GetAcceptanceCriteriasHandler(IRepository<DataAccess.Entities.AcceptanceCriteria> acceptnceCriteriasRepository)
        {
            this.acceptnceCriteriasRepository = acceptnceCriteriasRepository;
        }

        public Task<GetAcceptanceCriteriasResponse> Handle(GetAcceptanceCriteriasRequest request, CancellationToken cancellationToken)
        {
            var acceptanceCriterias = this.acceptnceCriteriasRepository.GetAll();

            var domainAcceptnceCriterias = acceptanceCriterias.Select(x => new Domain.Models.AcceptanceCriteria()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetAcceptanceCriteriasResponse()
            {
                Data = domainAcceptnceCriterias.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
