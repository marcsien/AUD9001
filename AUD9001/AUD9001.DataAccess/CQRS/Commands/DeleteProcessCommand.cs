using AUD9001.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class DeleteProcessCommand : CommandBase<Process, Process>
    {
        public async override Task<Process> Execute(AUD9001StorageContext context)
        {
            context.Processes.Remove(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
