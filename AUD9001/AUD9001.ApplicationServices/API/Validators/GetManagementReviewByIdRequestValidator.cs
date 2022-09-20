using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class GetManagementReviewByIdRequestValidator : AbstractValidator<GetManagementReviewByIdRequest>
    {
        public GetManagementReviewByIdRequestValidator()
        {
            this.RuleFor(x => x.ManagementReviewId).NotEmpty().WithMessage("ManagementReviewId cannot be empty");
            this.RuleFor(x => x.ManagementReviewId).NotEqual(0).WithMessage("ManagementReviewId cannot equal 0");
        }
    }
}
