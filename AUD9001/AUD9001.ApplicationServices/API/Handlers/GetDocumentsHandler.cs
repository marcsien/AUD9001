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
    class GetDocumentsHandler : IRequestHandler<GetDocumentsRequest, GetDocumentsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Document> documentRepository;

        public GetDocumentsHandler(IRepository<Document> documentRepository)
        {
            this.documentRepository = documentRepository;
        }

        public Task<GetDocumentsResponse> Handle(GetDocumentsRequest request, CancellationToken cancellationToken)
        {
            var documents = this.documentRepository.GetAll();

            var domainDocuments = documents.Select(x => new Domain.Models.Document()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetDocumentsResponse()
            {
                Data = domainDocuments.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
