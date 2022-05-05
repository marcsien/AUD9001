using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetRoleQuery : QueryBase<Role>
    {
        public int Id { get; set; }
        public override async Task<Role> Execute(AUD9001StorageContext context)
        {
            var role = await context.Roles.FirstOrDefaultAsync(x => x.Id == this.Id);
            return role;
        }
    }
}