using AUD9001.ApplicationServices.API.Domain;
using AUD9001.DataAccess.CQRS;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess.CQRS.Commands;
using AUD9001.ApplicationServices.API.Hasher;

namespace AUD9001.ApplicationServices.API.Handlers
{
    public class AddUserHandler : IRequestHandler<AddUserRequest, AddUserResponse>
    {
        private readonly ICommandExecutor commandExecutor;
        private readonly IMapper mapper;
        private readonly IHasher hasher;

        public AddUserHandler(ICommandExecutor commandExecutor, IMapper mapper, IHasher hasher)
        {
            this.commandExecutor = commandExecutor;
            this.mapper = mapper;
            this.hasher = hasher;
        }

        public async Task<AddUserResponse> Handle(AddUserRequest request, CancellationToken cancellationToken)
        {
            var user = this.mapper.Map<User>(request);
            var command = new AddUserCommand() { Parameter = user };
            command.Parameter.Salt = await hasher.GenerateSalt();
            command.Parameter.Password = await hasher.GenerateHash(command.Parameter.Salt, command.Parameter.Password);
            var processFromDb = await this.commandExecutor.Execute(command);
            return new AddUserResponse()
            {
                Data = this.mapper.Map<Domain.Models.User>(processFromDb)
            };
        }
    }
}
