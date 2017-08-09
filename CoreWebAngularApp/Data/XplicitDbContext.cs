using CoreWebAngularApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CoreWebAngularApp.Data
{
    public class XplicitDbContext : DbContext
    {

        public XplicitDbContext(DbContextOptions<XplicitDbContext> options) : base(options)
        {
            Database.Migrate();
        }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Company> Companies { get; set; }
        
    }
}