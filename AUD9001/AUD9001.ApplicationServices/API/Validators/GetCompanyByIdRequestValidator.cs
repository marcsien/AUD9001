using AUD9001.ApplicationServices.API.Domain.Company;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class GetCompanyByIdRequestValidator : AbstractValidator<GetCompanyByIdRequest>
    {
        public GetCompanyByIdRequestValidator()
        {
            this.RuleFor(x => x.CompanyId).NotEmpty().WithMessage("CompanyId cannot be empty");
            this.RuleFor(x => x.CompanyId).NotEqual(0).WithMessage("CompanyId cannot equal 0");
        }
    }
}