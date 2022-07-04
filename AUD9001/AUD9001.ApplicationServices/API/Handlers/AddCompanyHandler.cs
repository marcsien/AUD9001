using AUD9001.ApplicationServices.API.Domain.Company;
using AUD9001.ApplicationServices.API.Domain;
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

namespace AUD9001.ApplicationServices.API.Handlers
{
    internal class AddCompanyHandler : IRequestHandler<AddCompanyRequest, AddCompanyResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;

        public AddCompanyHandler(ICommandExecutor commandExecutor, IMapper mapper)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
        }

        public async Task<AddCompanyResponse> Handle(AddCompanyRequest request, CancellationToken cancellationToken)
        {
            var company = this.mapper.Map<Company>(request);
            var command = new AddCompanyCommand() { Parameter = company };
            var companyFromDb = await this.commandExecutor.Execute(command);
            return new AddCompanyResponse()
            {
                Data = this.mapper.Map<Domain.Models.Company>(companyFromDb)
            };
        }
    }
}
