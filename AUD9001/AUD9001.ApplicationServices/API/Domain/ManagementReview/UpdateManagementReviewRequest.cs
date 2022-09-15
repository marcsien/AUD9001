using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.ManagementReview
{
    public class UpdateManagementReviewRequest : RequestBase<UpdateManagementReviewResponse>
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public DateTime Date { get; set; }
        public int? CompanyID { get; set; }
    }
}
