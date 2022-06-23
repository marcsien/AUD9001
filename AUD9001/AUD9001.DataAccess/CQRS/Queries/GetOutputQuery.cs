using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetOutputQuery : QueryBase<Output>
    {
        public int Id { get; set; }
        public override async Task<Output> Execute(AUD9001StorageContext context)
        {
            var output = await context.Outputs.FirstOrDefaultAsync(x => x.Id == this.Id);
            return output;
        }
    }
}
