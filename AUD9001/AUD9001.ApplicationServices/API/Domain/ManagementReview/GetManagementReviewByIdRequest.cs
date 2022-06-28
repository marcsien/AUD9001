using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.ManagementReview
{
    public class GetManagementReviewByIdRequest : RequestBase<GetManagementReviewByIdResponse>
    {
        public int ManagementReviewId { get; set; }
    }
}
