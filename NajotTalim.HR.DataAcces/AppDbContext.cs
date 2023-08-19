using Microsoft.EntityFrameworkCore;
namespace NajotTalim.HR.DataAcces

{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOption) : base(dbContextOption)
        {
                
        }
        public Dbset<Employee> Employees { get; set; }
    }
}