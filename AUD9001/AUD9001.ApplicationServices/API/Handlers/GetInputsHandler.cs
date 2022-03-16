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
    public class GetInputsHandler : IRequestHandler<GetInputsRequest, GetInputsResponse>
    {
        private readonly IRepository<Input> inputRepository;

        public GetInputsHandler(IRepository<DataAccess.Entities.Input> inputRepository)
        {
            this.inputRepository = inputRepository;
        }

        public Task<GetInputsResponse> Handle(GetInputsRequest request, CancellationToken cancellationToken)
        {
            var inputs = this.inputRepository.GetAll();

            var domainInputs = inputs.Select(x => new Domain.Models.Input()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetInputsResponse()
            {
                Data = domainInputs.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
