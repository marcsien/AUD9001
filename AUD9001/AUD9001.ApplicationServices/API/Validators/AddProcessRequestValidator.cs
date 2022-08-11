using AUD9001.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class AddProcessRequestValidator : AbstractValidator<AddProcessRequest>
    {
        public AddProcessRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            this.RuleFor(x => x.CompanyID).NotEmpty().WithMessage("CompanyID cannot be empty");
            this.RuleFor(x => x.CompanyID).NotEqual(0).WithMessage("CompanyID cannot equal 0");
        }
    }
}
