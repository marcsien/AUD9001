using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Company;
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
    internal class GetCompanyByIdHandler : IRequestHandler<GetCompanyByIdRequest, GetCompanyByIdResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetCompanyByIdHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<GetCompanyByIdResponse> Handle(GetCompanyByIdRequest request, CancellationToken cancellationToken)
        {
            var query = new GetCompanyQuery()
            {
                Id = request.CompanyId
            };
            var company = await this.queryexecutor.Execute(query);

            if (company == null)
            {
                return new GetCompanyByIdResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedCompany = this.mapper.Map<Domain.Models.Company>(company);
            var response = new GetCompanyByIdResponse() { Data = mappedCompany };
            return response;
        }
    }
}
