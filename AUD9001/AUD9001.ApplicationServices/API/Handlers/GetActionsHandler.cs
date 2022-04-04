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
    public class GetActionsHandler : IRequestHandler<GetActionsRequest, GetActionsResponse>
    {
        private readonly IRepository<DataAccess.Entities.Action> actionRepository;

        public GetActionsHandler(IRepository<DataAccess.Entities.Action> actionRepository)
        {
            this.actionRepository = actionRepository;
        }

        public async Task<GetActionsResponse> Handle(GetActionsRequest request, CancellationToken cancellationToken)
        {
            var actions = await this.actionRepository.GetAll();

            var domainActions = actions.Select(x => new Domain.Models.Action()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetActionsResponse()
            {
                Data = domainActions.ToList()
            };

            return response;
        }
    }
}
