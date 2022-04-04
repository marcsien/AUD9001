using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess;
using AUD9001.DataAccess.Entities;
using AutoMapper;
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
        private readonly IMapper mapper;

        public GetInputsHandler(IRepository<DataAccess.Entities.Input> inputRepository,IMapper mapper)
        {
            this.inputRepository = inputRepository;
            this.mapper = mapper;
        }

        public async Task<GetInputsResponse> Handle(GetInputsRequest request, CancellationToken cancellationToken)
        {
            var mappedInputs = this.mapper.Map<List<Domain.Models.Input>>(await this.inputRepository.GetAll());
            var response = new GetInputsResponse() { Data = mappedInputs };
            return response;
        }
    }
}
