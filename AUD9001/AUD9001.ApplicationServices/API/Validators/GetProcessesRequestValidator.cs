using AUD9001.ApplicationServices.API.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class GetProcessesRequestValidator : AbstractValidator<GetProcessesRequest>
    {
        public GetProcessesRequestValidator()
        {
            this.RuleFor(x => x.Name).Matches(new Regex(@"^\D*$")).WithMessage("Name cannot be number");
        }
    }
}
