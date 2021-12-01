using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AUD9001.DataAccess
{
    class AUD9001StorageContext : DbContext
    {
        public AUD9001StorageContext(DbContextOptions<AUD9001StorageContext> opt ) : base(opt)
        {

        }

        public DbSet<Process> Processes { get; set; }
    }
}
