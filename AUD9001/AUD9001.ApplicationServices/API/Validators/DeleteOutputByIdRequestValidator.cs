using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Output;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class DeleteOutputByIdRequestValidator : AbstractValidator<DeleteOutputByIdRequest>
    {
        public DeleteOutputByIdRequestValidator()
        {
            this.RuleFor(x => x.OutputId).NotEmpty().WithMessage("OutputID cannot be empty");
            this.RuleFor(x => x.OutputId).NotEqual(0).WithMessage("OutputID cannot equal 0");
        }
    }
}
