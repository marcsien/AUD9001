using AUD9001.ApplicationServices.API.Domain;
using AUD9001.ApplicationServices.API.Domain.ManagementReview;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Validators
{
    public class DeleteManagementReviewByIdRequestValidator : AbstractValidator<DeleteManagementReviewByIdRequest>
    {
        public DeleteManagementReviewByIdRequestValidator()
        {
            this.RuleFor(x => x.ManagementReviewId).NotEmpty().WithMessage("ManagementReviewID cannot be empty");
            this.RuleFor(x => x.ManagementReviewId).NotEqual(0).WithMessage("ManagementReviewID cannot equal 0");
        }
    }
}
