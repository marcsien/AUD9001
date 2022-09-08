using AUD9001.ApplicationServices.API.Domain.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class AddCompanyRequestValidator : AbstractValidator<AddCompanyRequest>
    {
        public AddCompanyRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}
