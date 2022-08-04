using AUD9001.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class UpdateOutputCommand : CommandBase<Output, Output>
    {
        public async override Task<Output> Execute(AUD9001StorageContext context)
        {
            context.Outputs.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
