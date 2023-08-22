using Microsoft.EntityFrameworkCore;
using NajotTalim.HR.DataAcces;

namespace NajotTalim.HR.DataAccess
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions)
        {

        }

        public DbSet<Employee> Employees { get; set; } 
    }
}
