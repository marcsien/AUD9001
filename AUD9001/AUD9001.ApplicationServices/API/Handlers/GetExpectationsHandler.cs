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
    public class GetExpectationsHandler : IRequestHandler<GetExpectationsRequest, GetExpectationsResponse>
    {
        private readonly IRepository<Expectation> expectationRepository;

        public GetExpectationsHandler(IRepository<DataAccess.Entities.Expectation> expectationRepository)
        {
            this.expectationRepository = expectationRepository;
        }

        public async Task<GetExpectationsResponse> Handle(GetExpectationsRequest request, CancellationToken cancellationToken)
        {
            var expectations = await this.expectationRepository.GetAll();

            var domainExpectations = expectations.Select(x => new Domain.Models.Expectation()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetExpectationsResponse()
            {
                Data = domainExpectations.ToList()
            };

            return response;
        }
    }
}
