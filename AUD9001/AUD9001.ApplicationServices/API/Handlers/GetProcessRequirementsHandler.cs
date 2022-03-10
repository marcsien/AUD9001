﻿using AUD9001.ApplicationServices.API.Domain;
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
    public class GetProcessRequirementsHandler : IRequestHandler<GetProcessRequirementsRequest, GetProcessRequirementsResponse>
    {
        private readonly IRepository<ProcessRequirement> processRequirementRepository;

        public GetProcessRequirementsHandler(IRepository<ProcessRequirement> processRequirementRepository)
        {
            this.processRequirementRepository = processRequirementRepository;
        }

        public Task<GetProcessRequirementsResponse> Handle(GetProcessRequirementsRequest request, CancellationToken cancellationToken)
        {
            var processrequirements = this.processRequirementRepository.GetAll();

            var domainprocessrequirements = processrequirements.Select(x => new Domain.Models.ProcessRequirement()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetProcessRequirementsResponse()
            {
                Data = domainprocessrequirements.ToList()
            };

            return Task.FromResult(response);
        }
    }
}
