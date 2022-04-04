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
    public class GetRolesHandler : IRequestHandler<GetRolesRequest, GetRolesResponse>
    {
        private readonly IRepository<Role> roleRepository;
        public GetRolesHandler(IRepository<DataAccess.Entities.Role> roleRepository)
        {
            this.roleRepository = roleRepository;
        }
        public async Task<GetRolesResponse> Handle(GetRolesRequest request, CancellationToken cancellationToken)
        {
            var roles = await this.roleRepository.GetAll();

            var domainRoles = roles.Select(x => new Domain.Models.Role()
            {
                Name = x.Name,
                Description = x.Description
            });

            var response = new GetRolesResponse()
            {
                Data = domainRoles.ToList()
            };

            return response;
        }
    }
}
