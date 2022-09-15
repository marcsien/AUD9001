using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class UpdateManagementReviewRequestValidator : AbstractValidator<UpdateManagementReviewRequest>
    {
        public UpdateManagementReviewRequestValidator()
        {
            this.RuleFor(x => x.Id).NotEmpty().WithMessage("Id cannot be empty");
        }
    }
}