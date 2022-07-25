using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetManagementReviewsQuery : QueryBase<List<ManagementReview>>
    {
        public override Task<List<ManagementReview>> Execute(AUD9001StorageContext context)
        {
                var processes = context.ManagementReviews
                                        .Include(p => p.Company)
                                        .ToListAsync();
                return processes;
        }
    }
}
