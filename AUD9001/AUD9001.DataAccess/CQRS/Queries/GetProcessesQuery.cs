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
        public string Name { get; set; }
        public override Task<List<Process>> Execute(AUD9001StorageContext context)
        {
            if(String.IsNullOrEmpty(this.Name))
            {
                var processes = context.Processes
                                        .Include(p => p.Company)
                                        .ToListAsync();
                return processes;
            }
            else
            {
                var processes = context.Processes
                                        .Where(x => x.Name == this.Name)
                                        .Include(p => p.Company)
                                        .ToListAsync();
                return processes;
            }           
        }
    }
}
