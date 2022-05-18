using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.User;
using AUD9001.ApplicationServices.API.ErrorHandling;
using AUD9001.DataAccess;
using AUD9001.DataAccess.CQRS.Queries;
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
    public class VaalidateUserHandler : IRequestHandler<ValidateUserRequest, ValidateUserResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public VaalidateUserHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<ValidateUserResponse> Handle(ValidateUserRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Username = request.Username
            };
            var user = await this.queryexecutor.Execute(query);

            if (user == null)
            {
                return new ValidateUserResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedUser = this.mapper.Map<Domain.Models.User>(user);
            var response = new ValidateUserResponse() { Data = mappedUser };
            return response;
        }
    }
}
