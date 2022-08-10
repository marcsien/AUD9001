using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUD9001.DataAccess.Entities;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class DeleteManagementReviewCommand : CommandBase<ManagementReview, ManagementReview>
    {
        public async override Task<ManagementReview> Execute(AUD9001StorageContext context)
        {
            context.ManagementReviews.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
