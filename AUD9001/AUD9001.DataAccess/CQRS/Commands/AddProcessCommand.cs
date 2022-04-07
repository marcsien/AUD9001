using AUD9001.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class AddProcessCommand : CommandBase<Process, Process>
    {
        public override async Task<Process> Execute(AUD9001StorageContext context)
        {
            await context.Processes.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
