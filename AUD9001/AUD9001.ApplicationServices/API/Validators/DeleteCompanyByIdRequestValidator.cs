using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class DeleteCompanyByIdRequestValidator : AbstractValidator<DeleteCompanyByIdRequest>
    {
        public DeleteCompanyByIdRequestValidator()
        {
            this.RuleFor(x => x.CompanyId).NotEmpty().WithMessage("CompanyID cannot be empty");
            this.RuleFor(x => x.CompanyId).NotEqual(0).WithMessage("CompanyID cannot equal 0");
        }
    }
}
