using AUD9001.DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace AUD9001.DataAccess
{
    public class AUD9001StorageContext : DbContext
    {
        public AUD9001StorageContext(DbContextOptions<AUD9001StorageContext> opt ) : base(opt)
        {

        }

        public DbSet<Process> Processes { get; set; }
    }
}
