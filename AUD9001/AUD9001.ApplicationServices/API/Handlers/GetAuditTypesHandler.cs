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
    public class GetAuditTypesHandler : IRequestHandler<GetAuditTypesRequest, GetAuditTypesResponse>
    {
        private readonly IRepository<AuditType> auditTypeRepository;

        public GetAuditTypesHandler(IRepository<DataAccess.Entities.AuditType> auditTypeRepository)
        {
            this.auditTypeRepository = auditTypeRepository;
        }

        public Task<GetAuditTypesResponse> Handle(GetAuditTypesRequest request, CancellationToken cancellationToken)
        {
            var auditTypes = this.auditTypeRepository.GetAll();

            var domainAuditTypes = auditTypes.Select(x => new Domain.Models.AuditType()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetAuditTypesResponse()
            {
                Data = domainAuditTypes.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
