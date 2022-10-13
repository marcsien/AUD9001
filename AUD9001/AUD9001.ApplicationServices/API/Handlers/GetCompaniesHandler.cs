using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.ErrorHandling;
using AUD9001.DataAccess;
using AUD9001.DataAccess.CQRS.Queries;
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
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryexecutor;

        public GetCompaniesHandler(IMapper mapper, IQueryExecutor executor)
        {
            this.mapper = mapper;
            this.queryexecutor = executor;
        }

        public async Task<GetCompaniesResponse> Handle(GetCompaniesRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompaniesQuery();
            var companies = await this.queryexecutor.Execute(query);
            if (companies == null)
            {
                return new GetCompaniesResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }
            var mappedCompanies = this.mapper.Map<List<Domain.Models.Company>>(companies);
            var response = new GetCompaniesResponse() { Data = mappedCompanies };
            return response;
        }
    }
}
