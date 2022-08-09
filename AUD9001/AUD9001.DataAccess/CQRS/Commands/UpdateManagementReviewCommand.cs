using AUD9001.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class UpdateManagementReviewCommand : CommandBase<ManagementReview, ManagementReview>
    {
        public async override Task<ManagementReview> Execute(AUD9001StorageContext context)
        {
            context.ManagementReviews.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
