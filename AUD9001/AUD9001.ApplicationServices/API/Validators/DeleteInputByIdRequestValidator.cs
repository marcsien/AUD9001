using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class DeleteInputByIdRequestValidator : AbstractValidator<DeleteInputByIdRequest>
    {
        public DeleteInputByIdRequestValidator()
        {
            this.RuleFor(x => x.InputId).NotEmpty().WithMessage("OutputID cannot be empty");
            this.RuleFor(x => x.InputId).NotEqual(0).WithMessage("OutputID cannot equal 0");
        }
    }
}
