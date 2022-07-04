using AUD9001.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Commands
{
    public class AddCompanyCommand : CommandBase<Company, Company>
    {
        public async override Task<Company> Execute(AUD9001StorageContext context)
        {
            await context.Companies.AddAsync(this.Parameter);
            await context.SaveChangesAsync();
            return this.Parameter;
        }
    }
}
