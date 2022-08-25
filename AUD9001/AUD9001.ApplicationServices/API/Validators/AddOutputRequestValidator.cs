using AUD9001.ApplicationServices.API.Domain.Output;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class AddOutputRequestValidator : AbstractValidator<AddOutputRequest>
    {
        public AddOutputRequestValidator()
        {
            this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name cannot be empty");
            this.RuleFor(x => x.ProcessID).NotEmpty().WithMessage("ProcessID cannot be empty");
        }
    }
}
