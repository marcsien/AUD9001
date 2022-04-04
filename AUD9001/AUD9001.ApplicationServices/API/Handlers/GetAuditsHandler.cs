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
    public class GetAuditsHandler : IRequestHandler<GetAuditsRequest, GetAuditsResponse>
    {
        private readonly IRepository<Audit> auditRepository;

        public GetAuditsHandler(IRepository<DataAccess.Entities.Audit> auditsRepository)
        {
            this.auditRepository = auditsRepository;
        }

        public async Task<GetAuditsResponse> Handle(GetAuditsRequest request, CancellationToken cancellationToken)
        {
            var audits = await this.auditRepository.GetAll();

            var domainAudits = audits.Select(x => new Domain.Models.Audit()
            {
                AuditNumber = x.AuditNumber, 
                Description = x.Description
            });

            var response = new GetAuditsResponse()
            {
                Data = domainAudits.ToList()
            };

            return response;
        }
    }
}
