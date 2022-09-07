using AUD9001.ApplicationServices.API.Domain.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class UpdateCompanyRequestValidator : AbstractValidator<UpdateCompanyRequest>
    {
        public UpdateCompanyRequestValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
        }
    }
}