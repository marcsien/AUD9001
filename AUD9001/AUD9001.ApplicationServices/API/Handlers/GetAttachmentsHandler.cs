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
    public class GetAttachmentsHandler : IRequestHandler<GetAttachmentsRequest, GetAttachmentsResponse>
    {
        private readonly IRepository<Attachment> attachmentRepository;

        public GetAttachmentsHandler(IRepository<DataAccess.Entities.Attachment> attachmentRepository)
        {
            this.attachmentRepository = attachmentRepository;
        }

        public async Task<GetAttachmentsResponse> Handle(GetAttachmentsRequest request, CancellationToken cancellationToken)
        {
            var attachments = await this.attachmentRepository.GetAll();

            var domainAttachments = attachments.Select(x => new Domain.Models.Attachment()
            {
                FileName = x.FileName,
                Description = x.Description
            });

            var response = new GetAttachmentsResponse()
            {
                Data = domainAttachments.ToList()
            };

            return response;
        }
    }
}
