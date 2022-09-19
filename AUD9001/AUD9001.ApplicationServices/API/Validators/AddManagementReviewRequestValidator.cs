using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class AddManagementReviewRequestValidator : AbstractValidator<AddManagementReviewRequest>
    {
        public AddManagementReviewRequestValidator()
        {
            this.RuleFor(x => x.CompanyID).NotEmpty().WithMessage("CompanyID cannot be empty");
        }
    }
}
