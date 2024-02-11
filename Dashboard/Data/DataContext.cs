using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Dashboard.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder db)
        {

            base.OnModelCreating(db);
        }
    }
}