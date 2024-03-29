﻿using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess.CQRS.Queries
{
    public class GetCompaniesQuery : QueryBase<List<Company>>
    {
        public override Task<List<Company>> Execute(AUD9001StorageContext context)
        {
            return context.Companies
                .Include(x => x.Processes)
                .ToListAsync();
        }
    }
}
