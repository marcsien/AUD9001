using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetInputQuery : QueryBase<Input>
    {
        public int Id { get; set; }
        public override async Task<Input> Execute(AUD9001StorageContext context)
        {
            var input = await context.Inputs
                                            .AsNoTracking()
                                            .Include(p => p.Process)
                                            .FirstOrDefaultAsync(x => x.Id == this.Id);
            return input;
        }
    }
}
