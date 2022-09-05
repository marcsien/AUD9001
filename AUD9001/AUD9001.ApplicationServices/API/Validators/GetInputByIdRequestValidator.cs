using AUD9001.ApplicationServices.API.Domain.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class GetInputByIdRequestValidator : AbstractValidator<GetInputByIdRequest>
    {
        public GetInputByIdRequestValidator()
        {
            this.RuleFor(x => x.InputId).NotEmpty().WithMessage("InputId cannot be empty");
            this.RuleFor(x => x.InputId).NotEqual(0).WithMessage("InputId cannot equal 0");
        }
    }
}