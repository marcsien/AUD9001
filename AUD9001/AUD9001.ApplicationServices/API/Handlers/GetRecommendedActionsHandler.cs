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
    public class GetRecommendedActionsHandler : IRequestHandler<GetRecommendedActionsRequest, GetRecommendedActionsResponse>
    {
        private readonly IRepository<RecommendedAction> recommendedactionRepository;

        public GetRecommendedActionsHandler(IRepository<DataAccess.Entities.RecommendedAction> recommendedactionRepository)
        {
            this.recommendedactionRepository = recommendedactionRepository;
        }

        public Task<GetRecommendedActionsResponse> Handle(GetRecommendedActionsRequest request, CancellationToken cancellationToken)
        {
            var recommendedactions = this.recommendedactionRepository.GetAll();

            var domainrecommendedactions = recommendedactions.Select(x => new Domain.Models.RecommendedAction()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetRecommendedActionsResponse()
            {
                Data = domainrecommendedactions.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
