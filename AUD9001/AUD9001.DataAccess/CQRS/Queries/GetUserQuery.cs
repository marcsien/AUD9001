using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetUserQuery : QueryBase<User>
    {
        public string Username { get; set; }

        public override Task<User> Execute(AUD9001StorageContext context)
        {
            return context.Users
                .Include(x => x.Role)
                .FirstOrDefaultAsync(x => x.Login == this.Username);
        }
    }
}