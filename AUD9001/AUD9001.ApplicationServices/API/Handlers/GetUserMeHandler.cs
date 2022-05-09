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
    public class GetUserMeHandler : IRequestHandler<GetUserMeRequest, GetUserMeResponse>
    {
        private readonly IQueryExecutor queryexecutor;
        private readonly IMapper mapper;

        public GetUserMeHandler(IQueryExecutor queryexecutor, IMapper mapper)
        {
            this.queryexecutor = queryexecutor;
            this.mapper = mapper;
        }

        public async Task<GetUserMeResponse> Handle(GetUserMeRequest request, CancellationToken cancellationToken)
        {
            var query = new GetUserQuery()
            {
                Username = request.userLogin
            };
            var user = await this.queryexecutor.Execute(query);

            if (user == null)
            {
                return new GetUserMeResponse()
                {
                    Error = new ErrorModel(ErrorType.NotFound)
                };
            }

            var mappedUser = this.mapper.Map<Domain.Models.User>(user);
            var response = new GetUserMeResponse() { Data = mappedUser };
            return response;
        }
    }
}
