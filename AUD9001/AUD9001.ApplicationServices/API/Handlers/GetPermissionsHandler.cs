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
    public class GetPermissionsHandler : IRequestHandler<GetPermissionsRequest, GetPermissionsResponse>
    {
        private readonly IRepository<Permission> permissionRepository;

        public GetPermissionsHandler(IRepository<Permission> permissionRepository)
        {
            this.permissionRepository = permissionRepository;
        }

        public Task<GetPermissionsResponse> Handle(GetPermissionsRequest request, CancellationToken cancellationToken)
        {
            var permissions = this.permissionRepository.GetAll();

            var domainpermissions = permissions.Select(x => new Domain.Models.Permission()
            {
                Name = x.Name
            });

            var response = new GetPermissionsResponse()
            {
                Data = domainpermissions.ToList()
            };

            return Task.FromResult(response);
        }
    }

}
