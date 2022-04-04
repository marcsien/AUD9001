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
    public class GetAttentionsHandler : IRequestHandler<GetAttentionsRequest, GetAttentionsResponse>
    {
        private readonly IRepository<Attention> attentionRepository;

        public GetAttentionsHandler(IRepository<DataAccess.Entities.Attention> attentionRepository)
        {
            this.attentionRepository = attentionRepository;
        }

        public async Task<GetAttentionsResponse> Handle(GetAttentionsRequest request, CancellationToken cancellationToken)
        {
            var attentions = await this.attentionRepository.GetAll();

            var domainAttentions = attentions.Select(x => new Domain.Models.Attention()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetAttentionsResponse()
            {
                Data = domainAttentions.ToList()
            };

            return response;
        }
    }
}
