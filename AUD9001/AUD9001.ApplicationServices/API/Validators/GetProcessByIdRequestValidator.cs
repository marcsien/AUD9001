﻿using AUD9001.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class GetProcessByIdRequestValidator : AbstractValidator<GetProcessByIdRequest>
    {
        public GetProcessByIdRequestValidator()
        {
            this.RuleFor(x => x.ProcessId).NotEmpty().WithMessage("ProcessId cannot be empty");
            this.RuleFor(x => x.ProcessId).NotEqual(0).WithMessage("ProcessId cannot equal 0");
        }
    }
}
