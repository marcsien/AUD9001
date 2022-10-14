using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetCompanyQuery : QueryBase<Company>
    {
        public int Id { get; set; }

        public async override Task<Company> Execute(AUD9001StorageContext context)
        {
            var company = await context.Companies
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == this.Id);
            return company;
        }
    }
}
