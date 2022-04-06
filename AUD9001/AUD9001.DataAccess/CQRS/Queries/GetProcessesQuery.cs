using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetProcessesQuery : QueryBase<List<Process>>
    {
        public override Task<List<Process>> Execute(AUD9001StorageContext context)
        {
            return context.Processes.ToListAsync();
        }
    }
}
