using AUD9001.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class UpdateProcessRequestValidator : AbstractValidator<UpdateProcessRequest>
    {
        public UpdateProcessRequestValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");

        }
    }
}
