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
    public class GetDocVersionsHandler : IRequestHandler<GetDocVersionsRequest, GetDocVersionsResponse>
    {
        private readonly IRepository<DocVersion> docVersionRepository;

        public GetDocVersionsHandler(IRepository<DataAccess.Entities.DocVersion> docVersionRepository)
        {
            this.docVersionRepository = docVersionRepository;
        }

        public async Task<GetDocVersionsResponse> Handle(GetDocVersionsRequest request, CancellationToken cancellationToken)
        {
            var docVersions = await this.docVersionRepository.GetAll();

            var domainDocVersions = docVersions.Select(x => new Domain.Models.DocVersion()
            {
                Version = x.Version
            });

            var response = new GetDocVersionsResponse()
            {
                Data = domainDocVersions.ToList()
            };

            return response;
        }
    }
}
