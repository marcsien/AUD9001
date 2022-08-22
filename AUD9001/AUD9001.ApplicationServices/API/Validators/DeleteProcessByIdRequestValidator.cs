﻿using AUD9001.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class DeleteProcessByIdRequestValidator : AbstractValidator<DeleteProcessByIdRequest>
    {
        public DeleteProcessByIdRequestValidator()
        {
            this.RuleFor(x => x.ProcessId).NotEmpty().WithMessage("Name cannot be empty");
            this.RuleFor(x => x.ProcessId).NotEqual(0).WithMessage("CompanyID cannot equal 0");
            this.RuleFor(x => x.ProcessId).NotEqual(21).WithMessage("CompanyID cannot equal 21");
        }
    }
}
