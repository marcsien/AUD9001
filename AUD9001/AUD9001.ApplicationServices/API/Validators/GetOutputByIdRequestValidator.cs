using AUD9001.ApplicationServices.API.Domain.Output;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class GetOutputByIdRequestValidator : AbstractValidator<GetOutputByIdRequest>
    {
        public GetOutputByIdRequestValidator()
        {
            this.RuleFor(x => x.OutputId).NotEmpty().WithMessage("ProcessId cannot be empty");
            this.RuleFor(x => x.OutputId).NotEqual(0).WithMessage("ProcessId cannot equal 0");
        }
    }
}
