using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AUD9001.DataAccess
{
    public class AUD9001StorageContextFactory : IDesignTimeDbContextFactory<AUD9001StorageContext>
    {
        public AUD9001StorageContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AUD9001StorageContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-KOIET98;Initial Catalog=AUD9001Storage;Integrated Security=True");
            return new AUD9001StorageContext(optionsBuilder.Options);
        }

    }
}
