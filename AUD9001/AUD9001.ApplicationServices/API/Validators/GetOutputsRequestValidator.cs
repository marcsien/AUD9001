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
    public class GetOutputsRequestValidator : AbstractValidator<GetOutputsRequest>
    {
        public GetOutputsRequestValidator()
        {
        }
    }
}
