using AUD9001.DataAccess.CQRS;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess.CQRS.Commands;
using AUD9001.DataAccess.CQRS.Queries;
using AUD9001.DataAccess;
using AUD9001.ApplicationServices.API.Domain.Company;
using AUD9001.ApplicationServices.API.Domain;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class UpdateCompanyHandler : IRequestHandler<UpdateCompanyRequest, UpdateCompanyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IQueryExecutor queryExecutor;

        public UpdateCompanyHandler(ICommandExecutor commandExecutor, IMapper mapper, IQueryExecutor queryExecutor)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.queryExecutor = queryExecutor;
        }

        public async Task<UpdateCompanyResponse> Handle(UpdateCompanyRequest request, CancellationToken cancellationToken)
        {
            var checkquery = new GetCompanyQuery()
            {
                Id = request.Id
            };
            var company = await this.queryExecutor.Execute(checkquery);

            if (company == null)
            {
                return new UpdateCompanyResponse()
                {
                    Error = new ErrorModel("Nie znaleziono Company z Id: " + request.Id)
                };
            }

            var command = new UpdateCompanyCommand()
            {
                Parameter = mapper.Map<Company>(request)
            };

            var updatedCompany = await this.commandExecutor.Execute(command);

            return new UpdateCompanyResponse()
            {
                Data = this.mapper.Map<Domain.Models.Company>(updatedCompany)
            };
        }
    }
}
