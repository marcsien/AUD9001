﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.ApplicationServices.API.Domain.ManagementReview
{
    public class AddManagementReviewRequest : RequestBase<AddManagementReviewResponse>
    {
        public int Number { get; set; }
        public int CompanyID { get; set; }
    }
}
