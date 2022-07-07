using AUD9001.DataAccess.Entities;
using AUD9001.DataAccess;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using AUD9001.ApplicationServices.API.Domain;
using Microsoft.AspNetCore.Authorization;
using AUD9001.ApplicationServices.API.Domain.User;
using System.Net.Http.Headers;
using System.Text;

namespace AUD9001.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ApiControllerBase
    {
        public UsersController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetUsersRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("")]
        public async Task<IActionResult> AddUser([FromQuery] AddUserRequest request)
        {
            var response = await this.mediator.Send(request);
            return this.Ok(response);
        }

        [HttpGet]
        [Route("/users/me/")]
        public async Task<IActionResult> GetMeUser()
        {
            GetUserMeRequest request = new GetUserMeRequest();

            if (Request.Headers.ContainsKey("Authorization"))
            {
                var authHeader = AuthenticationHeaderValue.Parse(Request.Headers["Authorization"]);
                var credentialBytes = Convert.FromBase64String(authHeader.Parameter);
                var credentials = Encoding.UTF8.GetString(credentialBytes).Split(new[] { ':' }, 2);
                request.Login = credentials[0];
            }

                //var response = await this.mediator.Send(request);
                return await this.HandleRequest<GetUserMeRequest, GetUserMeResponse>(request);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("/users/authenticate/")]
        public async Task<IActionResult> PostAuthenticateUser([FromBody] ValidateUserRequest request)
        {
            return await this.HandleRequest<ValidateUserRequest, ValidateUserResponse>(request);
        }

    }
}
