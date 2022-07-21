using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetOutputsQuery : QueryBase<List<Output>>
    {
        public string Name { get; set; }

        public override Task<List<Output>> Execute(AUD9001StorageContext context)
        {
            if (String.IsNullOrEmpty(this.Name))
            {
                var inputs = context.Outputs
                                        .Include(p => p.Process)
                                        .ToListAsync();
                return inputs;
            }
            else
            {
                var inputs = context.Outputs
                                        .Where(x => x.Name == this.Name)
                                        .Include(p => p.Process)
                                        .ToListAsync();
                return inputs;
            }
        }
    }
}
