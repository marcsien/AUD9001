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
    public class GetFactorsHandler : IRequestHandler<GetFactorsRequest, GetFactorsResponse>
    {
        private readonly IRepository<Factor> factorRepository;

        public GetFactorsHandler(IRepository<DataAccess.Entities.Factor> factorRepository)
        {
            this.factorRepository = factorRepository;
        }

        public Task<GetFactorsResponse> Handle(GetFactorsRequest request, CancellationToken cancellationToken)
        {
            var factors = this.factorRepository.GetAll();

            var domainFactors = factors.Select(x => new Domain.Models.Factor()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetFactorsResponse()
            {
                Data = domainFactors.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
