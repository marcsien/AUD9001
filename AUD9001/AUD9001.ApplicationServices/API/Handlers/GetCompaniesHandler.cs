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
    public class GetCompaniesHandler : IRequestHandler<GetCompaniesRequest, GetCompaniesResponse>
    {
        private readonly IRepository<Company> companyRepository;
        public GetCompaniesHandler(IRepository<DataAccess.Entities.Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public Task<GetCompaniesResponse> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
        {
            var companies = this.companyRepository.GetAll();

            var domainCompanies = companies.Select(x => new Domain.Models.Company()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetCompaniesResponse()
            {
                Data = domainCompanies.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
