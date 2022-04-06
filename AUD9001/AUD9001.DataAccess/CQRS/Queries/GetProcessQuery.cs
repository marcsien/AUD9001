using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetProcessQuery : QueryBase<Process>
    {
        public int Id { get; set; }
        public override async Task<Process> Execute(AUD9001StorageContext context)
        {
            var process = await context.Processes.FirstOrDefaultAsync(x => x.Id == this.Id);
            return process;
        }
    }
}
