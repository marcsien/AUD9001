using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;
using AutoMapper;
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
        private readonly IMapper mapper;

        public GetCompaniesHandler(IRepository<DataAccess.Entities.Company> companyRepository, IMapper mapper)
        {
            this.companyRepository = companyRepository;
            this.mapper = mapper;
        }

        public async Task<GetCompaniesResponse> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
        {
            var mappedCompanies = this.mapper.Map<List<Domain.Models.Company>>(await this.companyRepository.GetAll());
            var response = new GetCompaniesResponse() { Data = mappedCompanies };
            return response;
        }
    }
}
