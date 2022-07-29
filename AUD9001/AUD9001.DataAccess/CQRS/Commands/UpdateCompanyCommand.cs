using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUD9001.DataAccess.Entities;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class UpdateCompanyCommand : CommandBase<Company, Company>
    {
        public async override Task<Company> Execute(AUD9001StorageContext context)
        {
            context.Companies.Update(Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
