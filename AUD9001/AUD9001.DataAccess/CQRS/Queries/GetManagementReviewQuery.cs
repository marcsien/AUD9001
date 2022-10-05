using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetManagementReviewQuery : QueryBase<ManagementReview>
    {
        public int Id { get; set; }
        public override async Task<ManagementReview> Execute(AUD9001StorageContext context)
        {
            var managementReview = await context.ManagementReviews
                .AsNoTracking()
                .Include(x => x.Company)
                .FirstOrDefaultAsync(x => x.Id == this.Id);
            return managementReview;
        }
    }
}
