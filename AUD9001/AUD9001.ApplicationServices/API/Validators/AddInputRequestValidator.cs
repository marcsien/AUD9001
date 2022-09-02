using AUD9001.ApplicationServices.API.Domain.Input;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class AddInputRequestValidator : AbstractValidator<AddInputRequest>
    {
        public AddInputRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            this.RuleFor(x => x.ProcessID).NotEmpty().WithMessage("ProcessID cannot be empty");
        }
    }
}
