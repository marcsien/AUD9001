﻿using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.ErrorHandling;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace AUD9001.Controllers
{
    public abstract class ApiControllerBase : ControllerBase
    {
        protected readonly IMediator mediator;

        protected ApiControllerBase(IMediator mediator)
        {
            this.mediator = mediator;
        }

        protected async Task<IActionResult> HandleRequest<TRequest, TResponse>(TRequest request)
            where TRequest : IRequest<TResponse>
            where TResponse : ErrorResponseBase
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(
                    this.ModelState
                    .Where(x => x.Value.Errors.Any())
                    .Select(y => new { property = y.Key, errors = y.Value.Errors }));
            }
            var response = await this.mediator.Send(request);
            if (response.Error != null)
            {
                return this.ErrorResponse(response.Error);
            }
            return this.Ok(response);
        }

        private IActionResult ErrorResponse(ErrorModel error)
        {
            var httpCode = GetHttpStatusCode(error.Error);
            return StatusCode((int)httpCode, error);
        }

        private static HttpStatusCode GetHttpStatusCode(string error)
        {
            switch (error)
            {
                case ErrorType.NotFound:
                    return HttpStatusCode.NotFound;
                case ErrorType.InternalServerError:
                    return HttpStatusCode.InternalServerError;
                case ErrorType.Unauthorized:
                    return HttpStatusCode.Unauthorized;
                case ErrorType.RequestTooLarge:
                    return HttpStatusCode.RequestEntityTooLarge;
                case ErrorType.UnsupportedMediaType:
                    return HttpStatusCode.UnsupportedMediaType;
                case ErrorType.UnsupportedMethod:
                    return HttpStatusCode.MethodNotAllowed;
                case ErrorType.TooManyRequests:
                    return (HttpStatusCode)429;
                default:
                    return HttpStatusCode.BadRequest;
            }
        }
    }
}
